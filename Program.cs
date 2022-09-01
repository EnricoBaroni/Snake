using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main()
        {
            //Segun el numero introducido el tablero tendra tantas columnas y lineas
            //Console.WriteLine("De que tamaño quieres el juego");
            //int tamañoAdaptable = Convert.ToInt32(Console.ReadLine());
            int tamañoAdaptable = 5;
            int posicionActual = 13;
            int[] posicionesActuales = new int[] { 13, 14, 15 };
            bool finJuego = false;
            
            do
            {
                CrearTableroAdaptable(tamañoAdaptable, posicionActual, posicionesActuales);
                posicionActual = Jugar(tamañoAdaptable, posicionActual, posicionesActuales);
            } while (finJuego == false);
        }
        public static int Jugar(int tamaño, int posicionActual, int[] posicionesActuales)
        {
            int posicion = posicionActual;

            ConsoleKeyInfo pressedKey;
            pressedKey = Console.ReadKey();
            switch (pressedKey.Key.ToString())
            {
                case "RightArrow":
                    posicion += 1;
                    break;
                case "LeftArrow":
                    posicion -= 1;
                    break;
                case "UpArrow":
                    posicion -= tamaño;
                    break;
                case "DownArrow":
                    posicion += tamaño;
                    break;
            }
            Console.Clear();
            if (posicion <= 0 || posicion > (tamaño * tamaño) || ((posicion == posicionActual + 1) && posicionActual % 5 == 0) || ((posicion == posicionActual - 1) && posicionActual % 5 == 1))
            {
                EndGame();
            }
            return posicion;
        }
        public static void CrearTableroAdaptable(int tamañoAdaptable, int posicionActual, int[] posicionesActuales)
        {
            string[] valoresDisponibles = new string[tamañoAdaptable * tamañoAdaptable];

            for (int i = 1; i <= tamañoAdaptable * tamañoAdaptable; i++)
            {
                if (i == posicionActual)
                {
                    valoresDisponibles[i - 1] = "[o]";
                }
                else
                {
                    valoresDisponibles[i - 1] = "[ ]";
                }
            }
            Console.WriteLine("Use the keys to move");

            //Le restamos 1 porque el tamaño es distinto a la posicion del array por 1
            int value = 1;
            int linea = 1;
            for (int j = 0; j < valoresDisponibles.Length; j++)
            {
                if (value != (tamañoAdaptable * linea))
                {
                    Console.Write(valoresDisponibles[value - 1]);
                }
                else if (value == (tamañoAdaptable * linea))
                {
                    Console.WriteLine(valoresDisponibles[value - 1]);
                    linea += 1;
                }
                value += 1;
            }
        }
        public static void EndGame()
        {
            Console.WriteLine("GAME OVER");
            Console.WriteLine("Press 0 to Exit, any other number will restart the game");
            string pressed = Console.ReadLine();
            if (pressed == "0")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Main();
            }
        }
    }       
}
