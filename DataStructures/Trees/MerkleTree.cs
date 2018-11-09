using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public class MerkleNode<T>
    {
        public string Hash { get; }
        public MerkleNode<T> Parent { get; set; }
        public  MerkleNode<T> LeftNode { get; set; }
        public MerkleNode<T> RigthNode { get; set; }

        public MerkleNode(string hash)
        {
            this.Hash = hash;            
        }
    }
    public class MerkleTree<T>
    {
        private MerkleNode<T> _root;
        public MerkleNode<T> Root => _root;

        public MerkleTree(IEnumerable<T> chunks)
        {
            var leaves = FillLeaves(chunks);
            this._root = BuildMerkleTree(leaves);
        }

        private List<MerkleNode<T>> FillLeaves(IEnumerable<T> chunks)
        {
            List<MerkleNode<T>> leaves = new List<MerkleNode<T>>();
            chunks.ToList().ForEach(a => { leaves.Add(new MerkleNode<T>(ComputeSHA256Hash(a.ToString()))); });
            return leaves;
        }

        private MerkleNode<T> BuildMerkleTree(List<MerkleNode<T>> leaves)
        {
            //Builds the Merkle tree from a list of leaves. In case of an odd number of leaves, the last leaf is duplicated.
            int length = leaves.Count();
            if (length == 1) return leaves[0];
            List<MerkleNode<T>> parentList=new List<MerkleNode<T>>();
            int i = 0;
            while (i < length)
            {
                MerkleNode<T> left = leaves[i];
                MerkleNode<T> right = i + 1 < length ? leaves[i + 1] : left;

                parentList.Add(CreateParent(left, right));

                i += 2;
            }

            return BuildMerkleTree(parentList);
        }

        private MerkleNode<T> CreateParent(MerkleNode<T> left, MerkleNode<T> right)
        {
            MerkleNode<T> parent = new MerkleNode<T>(ComputeSHA256Hash(left.Hash + right.Hash))
            {
                LeftNode = left,
                RigthNode = right
            };
            left.Parent = right.Parent = parent;
            string output = $"Parent Hash:{parent.Hash}, Left Hash:{left.Hash}, Right Hash:{right.Hash}";
            Console.WriteLine(value: output);

            return parent;
        }

        private string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                foreach (var b in bytes)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
