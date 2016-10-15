#region License
// Copyright (c) 2016 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using NUnit.Framework;
using System;
using System.IO;

namespace DG.DentneD.Helpers.Test
{
    [TestFixture]
    public partial class DentneDHelpersTest
    {
        [Test]
        public void FileHelper_FindRandomFileName()
        {
            if (Directory.Exists("test"))
                Directory.Delete("test", true);
            Directory.CreateDirectory("test");

            Assert.That(FileHelper.FindRandomFileName("test", "", "txt"), Is.Not.EqualTo(null));

            Directory.Delete("test");
        }

        [Test]
        public void FileHelper_CreateFolder()
        {
            if (Directory.Exists("test"))
                Directory.Delete("test", true);
            Directory.CreateDirectory("test");

            Assert.IsTrue(FileHelper.CreateFolder("test\\test"));
            Assert.IsTrue(Directory.Exists("test\\test"));
            Directory.Delete("test\\test");

            Directory.Delete("test");
        }

        [Test]
        public void FileHelper_DeleteFolder()
        {
            if (Directory.Exists("test"))
                Directory.Delete("test", true);
            Directory.CreateDirectory("test");

            Assert.IsTrue(FileHelper.CreateFolder("test\\test"));
            Assert.IsTrue(Directory.Exists("test\\test"));
            Assert.IsTrue(FileHelper.DeleteFolder("test\\test", false));
            Assert.IsFalse(Directory.Exists("test\\test"));

            Assert.IsTrue(FileHelper.CreateFolder("test\\test"));
            Assert.IsTrue(Directory.Exists("test\\test"));
            Assert.IsTrue(FileHelper.DeleteFolder("test\\test", true));
            Assert.IsFalse(Directory.Exists("test\\test"));

            Directory.Delete("test");
        }

        [Test]
        public void FileHelper_DeleteFile()
        {
            if (Directory.Exists("test"))
                Directory.Delete("test", true);
            Directory.CreateDirectory("test");

            File.Create("test\\test1.txt").Dispose();
            File.Create("test\\test2.txt").Dispose();
            Assert.IsTrue(File.Exists("test\\test1.txt"));
            Assert.IsTrue(File.Exists("test\\test2.txt"));

            Assert.IsTrue(File.Exists("test\\test1.txt"));
            Assert.IsTrue(FileHelper.DeleteFile("test\\test1.txt", false));
            Assert.IsFalse(File.Exists("test\\test1.txt"));

            Assert.IsTrue(File.Exists("test\\test2.txt"));
            Assert.IsTrue(FileHelper.DeleteFile("test\\test2.txt", true));
            Assert.IsFalse(File.Exists("test\\test2.txt"));

            Directory.Delete("test");
        }

        [Test]
        public void FileHelper_PurgeFolder()
        {
            if (Directory.Exists("test"))
                Directory.Delete("test", true);
            Directory.CreateDirectory("test");
            Directory.CreateDirectory("test\\test2");

            File.Create("test\\test1.txt").Dispose();
            File.SetLastWriteTime("test\\test1.txt", DateTime.Now.AddDays(-5));
            File.Create("test\\test2.txt").Dispose();
            File.SetLastWriteTime("test\\test2.txt", DateTime.Now.AddDays(-5));
            File.Create("test\\test3.txt").Dispose();
            Assert.IsTrue(File.Exists("test\\test1.txt"));
            Assert.IsTrue(File.Exists("test\\test2.txt"));
            Assert.IsTrue(File.Exists("test\\test3.txt"));
            Assert.IsTrue(FileHelper.PurgeFolder("test", false, -2));
            Assert.IsFalse(File.Exists("test\\test1.txt"));
            Assert.IsFalse(File.Exists("test\\test2.txt"));
            Assert.IsTrue(File.Exists("test\\test3.txt"));
            Assert.IsTrue(Directory.Exists("test\\test2"));
            File.Delete("test\\test3.txt");

            File.Create("test\\test1.txt").Dispose();
            File.SetLastWriteTime("test\\test1.txt", DateTime.Now.AddDays(-5));
            File.Create("test\\test2.txt").Dispose();
            File.SetLastWriteTime("test\\test2.txt", DateTime.Now.AddDays(-5));
            File.Create("test\\test3.txt").Dispose();
            Assert.IsTrue(File.Exists("test\\test1.txt"));
            Assert.IsTrue(File.Exists("test\\test2.txt"));
            Assert.IsTrue(File.Exists("test\\test3.txt"));
            Assert.IsTrue(FileHelper.PurgeFolder("test", true, -2));
            Assert.IsFalse(File.Exists("test\\test1.txt"));
            Assert.IsFalse(File.Exists("test\\test2.txt"));
            Assert.IsTrue(File.Exists("test\\test3.txt"));
            Assert.IsTrue(Directory.Exists("test\\test2"));
            File.Delete("test\\test3.txt");

            File.Create("test\\test1.txt").Dispose();
            File.Create("test\\test2.txt").Dispose();
            File.Create("test\\test3.txt").Dispose();
            Assert.IsTrue(File.Exists("test\\test1.txt"));
            Assert.IsTrue(File.Exists("test\\test2.txt"));
            Assert.IsTrue(File.Exists("test\\test3.txt"));
            Assert.IsTrue(FileHelper.PurgeFolder("test", false, null));
            Assert.IsFalse(File.Exists("test\\test1.txt"));
            Assert.IsFalse(File.Exists("test\\test2.txt"));
            Assert.IsFalse(File.Exists("test\\test3.txt"));
            Assert.IsTrue(Directory.Exists("test\\test2"));
            Assert.IsTrue(Directory.Exists("test\\test2"));

            File.Create("test\\test1.txt").Dispose();
            File.Create("test\\test2.txt").Dispose();
            File.Create("test\\test3.txt").Dispose();
            Assert.IsTrue(File.Exists("test\\test1.txt"));
            Assert.IsTrue(File.Exists("test\\test2.txt"));
            Assert.IsTrue(File.Exists("test\\test3.txt"));
            Assert.IsTrue(FileHelper.PurgeFolder("test", true, null));
            Assert.IsFalse(File.Exists("test\\test1.txt"));
            Assert.IsFalse(File.Exists("test\\test2.txt"));
            Assert.IsFalse(File.Exists("test\\test3.txt"));
            Assert.IsTrue(Directory.Exists("test\\test2"));

            Directory.Delete("test", true);
        }

    }
}
