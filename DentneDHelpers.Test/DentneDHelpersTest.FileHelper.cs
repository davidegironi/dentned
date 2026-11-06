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

            Assert.That(FileHelper.CreateFolder("test\\test"), Is.EqualTo(true));
            Assert.That(Directory.Exists("test\\test"), Is.EqualTo(true));
            Directory.Delete("test\\test");

            Directory.Delete("test");
        }

        [Test]
        public void FileHelper_DeleteFolder()
        {
            if (Directory.Exists("test"))
                Directory.Delete("test", true);
            Directory.CreateDirectory("test");

            Assert.That(FileHelper.CreateFolder("test\\test"), Is.EqualTo(true));
            Assert.That(Directory.Exists("test\\test"), Is.EqualTo(true));
            Assert.That(FileHelper.DeleteFolder("test\\test", false), Is.EqualTo(true));
            Assert.That(Directory.Exists("test\\test"), Is.EqualTo(false));

            Assert.That(FileHelper.CreateFolder("test\\test"), Is.EqualTo(true));
            Assert.That(Directory.Exists("test\\test"), Is.EqualTo(true));
            Assert.That(FileHelper.DeleteFolder("test\\test", true), Is.EqualTo(true));
            Assert.That(Directory.Exists("test\\test"), Is.EqualTo(false));

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
            Assert.That(File.Exists("test\\test1.txt"), Is.EqualTo(true));
            Assert.That(File.Exists("test\\test2.txt"), Is.EqualTo(true));

            Assert.That(File.Exists("test\\test1.txt"), Is.EqualTo(true));
            Assert.That(FileHelper.DeleteFile("test\\test1.txt", false), Is.EqualTo(true));
            Assert.That(File.Exists("test\\test1.txt"), Is.EqualTo(false));

            Assert.That(File.Exists("test\\test2.txt"), Is.EqualTo(true));
            Assert.That(FileHelper.DeleteFile("test\\test2.txt", true), Is.EqualTo(true));
            Assert.That(File.Exists("test\\test2.txt"), Is.EqualTo(false));

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
            Assert.That(File.Exists("test\\test1.txt"), Is.EqualTo(true));
            Assert.That(File.Exists("test\\test2.txt"), Is.EqualTo(true));
            Assert.That(File.Exists("test\\test3.txt"), Is.EqualTo(true));
            Assert.That(FileHelper.PurgeFolder("test", false, -2), Is.EqualTo(true));
            Assert.That(File.Exists("test\\test1.txt"), Is.EqualTo(false));
            Assert.That(File.Exists("test\\test2.txt"), Is.EqualTo(false));
            Assert.That(File.Exists("test\\test3.txt"), Is.EqualTo(true));
            Assert.That(Directory.Exists("test\\test2"), Is.EqualTo(true));
            File.Delete("test\\test3.txt");

            File.Create("test\\test1.txt").Dispose();
            File.SetLastWriteTime("test\\test1.txt", DateTime.Now.AddDays(-5));
            File.Create("test\\test2.txt").Dispose();
            File.SetLastWriteTime("test\\test2.txt", DateTime.Now.AddDays(-5));
            File.Create("test\\test3.txt").Dispose();
            Assert.That(File.Exists("test\\test1.txt"), Is.EqualTo(true));
            Assert.That(File.Exists("test\\test2.txt"), Is.EqualTo(true));
            Assert.That(File.Exists("test\\test3.txt"), Is.EqualTo(true));
            Assert.That(FileHelper.PurgeFolder("test", true, -2), Is.EqualTo(true));
            Assert.That(File.Exists("test\\test1.txt"), Is.EqualTo(false));
            Assert.That(File.Exists("test\\test2.txt"), Is.EqualTo(false));
            Assert.That(File.Exists("test\\test3.txt"), Is.EqualTo(true));
            Assert.That(Directory.Exists("test\\test2"), Is.EqualTo(true));
            File.Delete("test\\test3.txt");

            File.Create("test\\test1.txt").Dispose();
            File.Create("test\\test2.txt").Dispose();
            File.Create("test\\test3.txt").Dispose();
            Assert.That(File.Exists("test\\test1.txt"), Is.EqualTo(true));
            Assert.That(File.Exists("test\\test2.txt"), Is.EqualTo(true));
            Assert.That(File.Exists("test\\test3.txt"), Is.EqualTo(true));
            Assert.That(FileHelper.PurgeFolder("test", false, null), Is.EqualTo(true));
            Assert.That(File.Exists("test\\test1.txt"), Is.EqualTo(false));
            Assert.That(File.Exists("test\\test2.txt"), Is.EqualTo(false));
            Assert.That(File.Exists("test\\test3.txt"), Is.EqualTo(false));
            Assert.That(Directory.Exists("test\\test2"), Is.EqualTo(true));
            Assert.That(Directory.Exists("test\\test2"), Is.EqualTo(true));

            File.Create("test\\test1.txt").Dispose();
            File.Create("test\\test2.txt").Dispose();
            File.Create("test\\test3.txt").Dispose();
            Assert.That(File.Exists("test\\test1.txt"), Is.EqualTo(true));
            Assert.That(File.Exists("test\\test2.txt"), Is.EqualTo(true));
            Assert.That(File.Exists("test\\test3.txt"), Is.EqualTo(true));
            Assert.That(FileHelper.PurgeFolder("test", true, null), Is.EqualTo(true));
            Assert.That(File.Exists("test\\test1.txt"), Is.EqualTo(false));
            Assert.That(File.Exists("test\\test2.txt"), Is.EqualTo(false));
            Assert.That(File.Exists("test\\test3.txt"), Is.EqualTo(false));
            Assert.That(Directory.Exists("test\\test2"), Is.EqualTo(true));

            Directory.Delete("test", true);
        }

    }
}
