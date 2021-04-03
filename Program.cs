using System;
using ProjectB.pages;
using ProjectB.Classes;
using ProjectB.DAL;

namespace ProjectB
{
    class Program
    {
        static void Main(string[] args)
        {
            DataStorageHandler.Init("ProjectB.json");
            Startscherm.startscherm();
        }
    }
}
