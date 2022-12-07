
using System.Collections.Generic;

namespace Task_1
{
    class Directory
    {
        public string Name { get; set; }
        public List<Directory> SubDirs { get; set; }
        public int Size { get; set; }
        public Directory parent { get; set; }
        public Directory(string name)
        {
            Name = name;
            SubDirs = new List<Directory>();
            Size = 0;
            this.parent = null;
        }
        public void AddSubDir(string dirname)
        {
            SubDirs.Add(new Directory(dirname, this));
        }
        public Directory(string name, Directory parent)
        {
            Name = name;
            SubDirs = new List<Directory>();
            Size = 0;
            this.parent = parent;
        }

        public Directory GetSubDir(string dirname)
        {
            foreach (Directory dir in SubDirs)
            {
                if (dir.Name == dirname)
                {
                    return dir;
                }
            }
            return null;
        }

        public void AddFileSize(int size)
        {
            this.Size += size;
            try{
                this.parent.AddFileSize(size);
            }
            catch(Exception e)
            {
                //do nothing
            }
        }



        public int test(Directory di) {
            var sum = 0;
            foreach (Directory dir in SubDirs)
            {
                if(dir.Size<100000)
                {
                    sum += dir.Size;
                }
                sum += dir.test(dir);
            }
            return sum;
        }
        public int GetSizeIfUnder100000()
        {
            if(this.Size<100000)
                return this.Size;
            else
                return 0;
        }

        public int getSumOfSize()
        {
            int sum = 0;
            foreach (Directory dir in SubDirs)
            {
                sum += dir.GetSizeIfUnder100000();
            }
            return sum;
        }
        public List<int> getSmallestToDelete(List<int> input, int maxSize)
        {
            if(this.Size>=maxSize)
            {
                input.Add(this.Size);
            }
            foreach (Directory dir in SubDirs)
            {
                dir.getSmallestToDelete(input, maxSize);
            }
            return input;
        }

    }
}