using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.DynamicProgramming
{
    class TowersOfHanoi
    {
        /*
         * 8.6 Towers of Hanoi: In the classic problem of the Towers of Hanoi, you have 3 towers and N disks of different sizes which can slide onto any tower.
         * The puzzle starts with disks sorted in ascending order of size from top to bottom (i.e., each disk sits on top of an even larger one).
         * You have the following constraints: 
         * (1) Only one disk can be moved at a time. 
         * (2) A disk is slid off the top of one tower onto another tower. 
         * (3) A disk cannot be placed on top of a smaller disk.
         * Write a program to move the disks from the first tower to the last using Stacks.
         * 
         * 
         * SOLUTION
         * This problem sounds like a good candidate for the Base Case and Build approach.
         * Let's start with the smallest possible example: n = 1.
         * Case n = 1. Can we move Disk 1 from Tower 1 to Tower 3? Yes.
         * 1. We simply move Disk 1 from Tower 1 to Tower 3.
         * Case n = 2. Can we move Disk 1 and Disk 2 from Tower 1 to Tower 3? Yes.
         * 1. Move Disk 1 from Tower 1 to Tower 2
         * 2. Move Disk 2 from Tower 1 to Tower 3
         * 3. Move Disk 1 from Tower 2 to Tower 3
         * Note how in the above steps, Tower 2 acts as a buffer, holding a disk while we move other disks to Tower 3. 
         * Case n = 3. Can we move Disk 1, 2, and 3 from Tower 1 to Tower 3? Yes. 
         * 1. We know we can move the top two disks from one tower to another (as shown earlier), so let's assume we've already done that. But instead, let's move them to Tower 2.
         * 2. Move Disk 3 to Tower 3.
         * 3. Move Disk 1 and Disk 2 to Tower 3. We already know how to do this-just repeat what we did in Step 1.
         * Case n = 4. Can we move Disk 1, 2, 3 and 4 from Tower 1 to Tower 3? Yes.
         * 1. Move Disks 1, 2, and 3 to Tower 2. We know how to do that from the earlier examples.
         * 2. Move Disk 4 to Tower 3.
         * 3. Move Disks 1, 2 and 3 back to Tower 3.
         * Remember that the labels of Tower 2 and Tower 3 aren't important. They're equivalent towers. 
         * So, moving disks to Tower 3 with Tower 2 serving as a buffer is equivalent to moving disks to Tower 2 with Tower 3 serving as a buffer.
         */
        public static void Test()
        {
            int n = 3;
            List<Tower> towers = new List<Tower>(3);

            for (int i = 1; i <= n; i++)
                towers.Add(new Tower(i));
            for (int i = n; i > 0; i--)
                towers[0].Add(new Disk(i));

            towers[0].MoveDisksTo(n, towers[2], towers[1]);
        }        
    }

    public class Tower
    {
        int index;
        Stack<Disk> disks;
        public Tower(int index)
        {
            this.index = index;
            this.disks = new Stack<Disk>();
        }

        public int GetIndex()
        {
            return index;
        }
        public string GetName()
        {
            return "Tower " + index;
        }
        public void Add(Disk d)
        {
            if (disks.Count > 0 && disks.Peek().GetIndex() < d.GetIndex())
                throw new InvalidOperationException("Cannot add " + d.GetName() + " to tower " + this.GetIndex());
            else
                disks.Push(d);
        }
        //This is used to move the top disk of this tower to dest tower
        private void MoveTopDiskTo(Tower dest)
        {
            Disk top = this.disks.Pop();
            Console.WriteLine("Move " + top.GetName() + " from " + this.GetName() + " to " + dest.GetName() + "");
            dest.Add(top);
        }

        //This is used to move disks from this tower to dest tower using the help of buffer tower
        public void MoveDisksTo(int n, Tower dest, Tower buffer)
        {
            if (n <= 0)
                return;
            MoveDisksTo(n - 1, buffer, dest);
            MoveTopDiskTo(dest);
            buffer.MoveDisksTo(n - 1, dest, this);
        }
    }
    public class Disk
    {
        int index;
        public Disk(int index)
        {
            this.index = index;
        }
        public int GetIndex()
        {
            return index;
        }
        public string GetName()
        {
            return "Disk " + index;
        }
    }
}
