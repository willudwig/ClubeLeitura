﻿using System;
using ClubeLeitura.ConsoleApp.Classes;

namespace ClubeLeitura.ConsoleApp
{
    internal class Program
    {
        internal static void Main(String[] args)
        {
            Console.Title = "Clube da Leitura";

            Menu menu = new();

            Input_Output informe = new();


            while (true)
            {
                menu.ApresentarOpcoes();

                string opcao = "";

                informe.InputarOpcao(opcao);
            }

        }
    }
}
