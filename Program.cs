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
            DataStorageHandler.Init("../../../DAL/ProjectB.json");
            Startscherm.startscherm();
            //Startscherm.startscherm();
        }
    }
}
