using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Pokodigon
{
    class Program
    {
        static List<Pokemon> pokemonsPc = new List<Pokemon>();
        static Pokemon[] pokemonsPlayer = new Pokemon[6];
        static Random random = new Random();
        static int index = 0, pokemonPlay=0,pokeList=5;
        
        static void Main(string[] args)
        {
            GeneratePokemon();
            int poke = random.Next(pokeList); 
            char continue_game;
           
            pokemonsPlayer[index] = new Pokemon("Pikachu", "Electrico");
            Attack attack = new Attack("Pararrayos");
            pokemonsPlayer[index].AddAttack(attack);
            attack = new Attack("Destello");
            pokemonsPlayer[index].AddAttack(attack);
           
            start();
            Console.Write("Presione cualquier tecla para iniciar el juego...");
            Console.ReadKey();
            Console.Clear();           
            do
            {
                Console.SetCursorPosition(31, 2);
                Console.Write("|");
                Console.SetCursorPosition(86, 2);
                Console.Write("|");
                PrintPokemon(poke);
                FightPokemon(poke);
                Console.SetCursorPosition(0, 16);
                Console.WriteLine("Desea seguir jugando(Y/N)");
                continue_game = Convert.ToChar(Console.ReadLine());
                Console.ReadKey();
                Console.Clear();                
                poke = random.Next(pokeList);

            } while (Char.ToUpper(continue_game) == 'Y' && pokeList > 0);

            Console.Clear();
            Console.SetCursorPosition(5, 5);
            Console.WriteLine("Juego Terminado!!");
            Console.SetCursorPosition(5, 7);
            Console.Write("Presione cualquier tecla para Terminar...");
            Console.ReadKey(); 

        }
        static void GeneratePokemon() {
            string[] poke = { "Quilava", "Charizard","Vulpix", "Arcanine", "Ponyta","Blastoise","Golduck", "Seel", "Shellder", "Kingler",
            "Electrode","Scyther","Electabuzz","Shinx","Ampharos","Hippopotas","Sandile","Krokorok","Dugtrio","Cubone","Sudowoodo","Nosepass",
                "Regirock","Cranidos","Rampardos","Scyther","Dragonite","Lugia","Taillow","Swellow"};
            string[,] types = { { "Fuego","0" },{ "Agua", "6" },{ "Electricidad", "11" },{ "Tierra", "16" }, { "Piedra", "21" },{ "Volador", "26" } };
            string[,] attacks = {{ "Mar llamas", "Poder solar" },{ "Torrente", "Danza lluvia" },{ "Pararrayos", "Destello " },
                { "Chorro arena", "Cabeza roca" }, { "Robustez", "Cabeza roca" }, { "Tornado", "Agallas" } };
            int name, type=0;
            Attack attack;

            for (int i = 0; i < 6; i++) {
               
                if ((i%2) == 0)
                    do
                    {
                        types[type, 0] = "";
                        type = random.Next(6);
                    } while (types[type, 0] == "");

                do {

                    name = (random.Next(4) + int.Parse(types[type, 1]));
                } while (poke[name] == "");

                pokemonsPc.Add(new Pokemon(poke[name], types[type, 0]));

                attack = new Attack(attacks[type, 0]);
                pokemonsPc[i].AddAttack(attack);
                attack = new Attack(attacks[type, 1]);
                pokemonsPc[i].AddAttack(attack);
                poke[name] = "";



            }
        
         }
        static int LifeBar(int x, int y, int z,int bar)
        {
            
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ______________________________");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("|");
            if ((bar - z) > 10)
            {
                if ((bar - z) > 20) Console.BackgroundColor = ConsoleColor.DarkGreen;
                else Console.BackgroundColor = ConsoleColor.DarkYellow;
            }
            else Console.BackgroundColor = ConsoleColor.Red;

            for (int i = 0; i < bar - z; i++)
                Console.Write(" ");

            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < z; i++)
                Console.Write(" ");
           
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");

            return bar - z;
        }

        //***************************************************************
        //*********************   Simulacion    *************************
        static void CreateLeftPokemon(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("  /)_/)");
            Console.SetCursorPosition(x, y + 1);
            Console.Write(" ( . .) ");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("c(\")(\") ");
        }
        static void CreateRightPokemon(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" (\\_(\\");
            Console.SetCursorPosition(x, y + 1);
            Console.Write(" (. . ) ");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("</   <\\");
        }
        static void AttackLeft(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            Console.SetCursorPosition(x + 1, y);
            Console.Write("-->");

        }
        static void AttackRight(int x, int y)
        {
           
            Console.SetCursorPosition(x + 2, y);
            Console.Write(" ");
            Console.SetCursorPosition(x - 1, y);
            Console.Write("<--");

        }
        static void PrintPokemon(int poke) {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("PC: {0} / LP {1}", pokemonsPc[poke].Name, pokemonsPc[poke].Life);
            LifeBar(0, 1, 0,30);
            CreateLeftPokemon(10, 4);
            Console.SetCursorPosition(55, 0);
            Console.WriteLine("Player: {0} / LP {1}", pokemonsPlayer[pokemonPlay].Name, pokemonsPlayer[pokemonPlay].Life);
            LifeBar(55, 1, 0,30);
            CreateRightPokemon(60, 4);

            Console.SetCursorPosition(70, 4);
            Console.Write("{0}", pokemonsPlayer[pokemonPlay].attacks[0].Name);
            Console.SetCursorPosition(70, 5);
            Console.Write("{0}", pokemonsPlayer[pokemonPlay].attacks[1].Name);
            Console.SetCursorPosition(70, 6);
            Console.Write("Cambiar pokemon");
          
        }
        static int MenuAttack(int initial_position) {
           
            Console.SetCursorPosition(86, initial_position);
            Console.Write("<<--");
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(86, initial_position);
                    Console.Write("    ");
                    initial_position++;
                    if (initial_position > 6) initial_position = 4;
                    Console.SetCursorPosition(86, initial_position);
                    Console.Write("<<--");

                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(86, initial_position);
                    Console.Write("    ");
                    initial_position--;
                    if (initial_position < 4) initial_position = 6;
                    Console.SetCursorPosition(86, initial_position);
                    Console.Write("<<--");
                    if (initial_position > 6) initial_position = 4;
                }

            } while (key.Key != ConsoleKey.Enter);
            return initial_position;
        }
        static void FightPokemon(int poke) {
            int turn = random.Next(2);
            int damage, initial_position = 4;
            decimal z, sum = 0;
            int lifePlayer = 30, lifePc = 30;
            do
            {
                int i;
                //Turno de la pc ********************************************************************
                if (turn == 0)
                {
                    cleanTurn(60, 10);
                    damage = random.Next(15, 65);
                    if (pokemonsPlayer[pokemonPlay].Life < damage) damage = pokemonsPlayer[pokemonPlay].Life;
                    pokemonsPlayer[pokemonPlay].DamagePoints(damage);
                    turn = 1;
                    Console.SetCursorPosition(4, 10);
                    Console.WriteLine("Turno de la PC");
                    Console.SetCursorPosition(4, 11);
                    Console.WriteLine("Ataque: {0}",pokemonsPc[poke].attacks[random.Next(2)].Name);
                    Console.SetCursorPosition(4, 12);
                    Console.WriteLine("Daño: {0}", damage);
                 
                    for (i = 0; i < 37; i++){
                        AttackLeft(18 + i, 5);
                        Thread.Sleep(30);
                    }
                    Console.SetCursorPosition(18 + i, 5);
                    Console.Write("    ");
                    z = Convert.ToDecimal(damage) / (150 / 30);

                    for (i = 0; i < z + 1; i++){
                        LifeBar(55, 1, i, lifePlayer);
                        Thread.Sleep(40);

                    }
                    sum += (z - Decimal.ToInt32(z));
                    lifePlayer -= Decimal.ToInt32(z);
                    if (sum >= 1){
                        lifePlayer--;
                        sum--;
                    }
                   
                    Console.SetCursorPosition(55, 0);
                    Console.WriteLine("Player: {0} / LP {1}   ", pokemonsPlayer[pokemonPlay].Name, pokemonsPlayer[pokemonPlay].Life);
                }

                //**************************************************************
                //Turno del jugador ***************************************

                if (turn == 1 && pokemonsPlayer[pokemonPlay].Life > 0)
                {
                    cleanTurn(4, 10);
                    Console.SetCursorPosition(60, 10);
                    Console.WriteLine("Turno del jugador");
                    initial_position = MenuAttack(initial_position);

                    while (initial_position == 6){
                        lifePlayer = 30;
                        lifePlayer-=ListPokemonsPlayer(60, 11);
                        initial_position = MenuAttack(initial_position);                       
                    }
                   
                    Console.SetCursorPosition(60, 11);
                    if (initial_position == 5)
                            Console.WriteLine("Ataque: {0}", pokemonsPlayer[pokemonPlay].attacks[1].Name);
                    else
                          Console.WriteLine("Ataque: {0}", pokemonsPlayer[pokemonPlay].attacks[0].Name);
                    Console.SetCursorPosition(60, 12);
                    Console.WriteLine("Daño: ");

                    do
                    {
                        Console.SetCursorPosition(67, 12);
                        Console.WriteLine("    ");
                        Console.SetCursorPosition(67, 12);
                        damage = int.Parse(Console.ReadLine());
                    } while (damage < 16 || damage > 65);
                   
                    if (pokemonsPc[poke].Life < damage) damage = pokemonsPc[poke].Life;
                    pokemonsPc[poke].DamagePoints(damage);
                    turn = 0;                  
                   

                    for (i = 0; i < 35; i++){
                        AttackRight(53 - i, 5);
                        Thread.Sleep(30);
                    }
                    Console.SetCursorPosition(53 - i, 5);
                    Console.Write("    ");
                    z = Convert.ToDecimal(damage) / (150 / 30);

                    for (i = 0; i < z + 1; i++) {
                        LifeBar(0, 1, i, lifePc);
                        Thread.Sleep(40);
                    }
                    lifePc -= Decimal.ToInt32(z);
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("PC: {0} / LP {1}      ", pokemonsPc[poke].Name, pokemonsPc[poke].Life);

                }

            } while (pokemonsPlayer[pokemonPlay].Life > 0 && pokemonsPc[poke].Life > 0);
            Console.SetCursorPosition(5, 10);
            pokemonsPc[poke].Life = 150;
            cleanTurn(4, 10);
            if (pokemonsPlayer[pokemonPlay].Life < 1)
                Console.WriteLine(" Has perdido la partida               ");
           
            else
            {
                Console.WriteLine(" Felicidades!!! Has ganado            ");
                if (random.Next(2) == 0)
                {
                    Console.WriteLine(" Enhorabuena!!! Has atrapado al pokemon");
                    
                    index++;
                    pokeList--;
                    pokemonsPlayer[index] = pokemonsPc[poke];
                    pokemonsPlayer[index].attacks[0].Name= pokemonsPc[poke].attacks[0].Name;
                    pokemonsPlayer[index].attacks[1].Name = pokemonsPc[poke].attacks[1].Name;                   
                    pokemonsPc.RemoveAt(poke);
                }
            }
            pokemonsPlayer[pokemonPlay].Life = 150;
           

        }
        static void start()
        {
            Console.WriteLine("                 _\\|/_\n                 (o o)");
            Console.WriteLine("  +----------oOO -{_}-OOo------------------------------------------------------------- +");
            Console.WriteLine("  |                                                                                    |");
            Console.WriteLine("  |                 POKODIGON  - KODIGO  -> JENNIFFER GRANADOS                         |");
            Console.WriteLine("  |                                                                                    |");
            Console.WriteLine("  |  Pokodigon es un juego de rol empleado por turnos donde podemos ir creando nuestro | ");
            Console.WriteLine("  |  grupo de pokemones para lograr ganar medallas en las diferentes ligas y gimnasios | ");
            Console.WriteLine("  |  que existen.                                                                      | ");
            Console.WriteLine("  |                                                                                    |");
            Console.WriteLine("  +-------------------------------------------------------------------------------------*");
            Console.WriteLine("                     Pokemon inicial");
            CreateRightPokemon(10, 13);
            Console.SetCursorPosition(18, 13);
            Console.WriteLine("Nombre: {0}", pokemonsPlayer[index].Name);
            Console.SetCursorPosition(18, 14);
            Console.WriteLine("Tipo: {0}", pokemonsPlayer[index].Type);
            Console.SetCursorPosition(18, 15);
            Console.Write("Lp: {0}", pokemonsPlayer[index].Life);
            Console.SetCursorPosition(37, 13);
            Console.Write("Ataques");
            Console.SetCursorPosition(37, 14);
            Console.Write("1. {0}", pokemonsPlayer[index].attacks[0].Name);
            Console.SetCursorPosition(37, 15);
            Console.Write("2. {0}\n\n", pokemonsPlayer[index].attacks[1].Name);

        }
        static void cleanTurn(int x,int y) {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("                         ");
            Console.SetCursorPosition(x, y+1);
            Console.WriteLine("                          ");
            Console.SetCursorPosition(x, y+2);
            Console.WriteLine("                         ");
        }
        static int ListPokemonsPlayer(int x,int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Lista de pokemons");
            int i;
            for (i=0; i < 6; i++) {
                Console.SetCursorPosition(x, y+i);
                if (pokemonsPlayer[i] == null)
                    break;
                Console.WriteLine("{0} {1} LP {2}", pokemonsPlayer[i].Name, pokemonsPlayer[i].Type, pokemonsPlayer[i].Life);
            }
            Console.SetCursorPosition(x+25, y);
            Console.Write("<<--");
            ConsoleKeyInfo key;
            int position = y;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(x + 25, position);
                    Console.Write("    ");
                    position++;
                    if (position > y+(i-1)) position = y;
                    Console.SetCursorPosition(x + 25, position);
                    Console.Write("<<--");

                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(x + 25, position);
                    Console.Write("    ");
                    position--;
                    if (position < y) position = y+(i-1);
                    Console.SetCursorPosition(x + 25, position);
                    Console.Write("<<--");
                }

            } while (key.Key != ConsoleKey.Enter);
            pokemonPlay = position-y;
            Console.WriteLine(pokemonPlay);
            decimal z = (150-pokemonsPlayer[pokemonPlay].Life) / (150 / 30);
            LifeBar(55, 1, Convert.ToInt32 (z), 30);
            Console.SetCursorPosition(55, 0);
            Console.WriteLine("Player: {0} / LP {1}   ", pokemonsPlayer[pokemonPlay].Name, pokemonsPlayer[pokemonPlay].Life);
            for (int j = 0; j < 6; j++) {
                Console.SetCursorPosition(x, y+j);
                Console.Write("                                                 ");

            }

            Console.SetCursorPosition(70, 4);
            Console.Write("               ");
            Console.SetCursorPosition(70, 4);
            Console.Write("{0}  ", pokemonsPlayer[pokemonPlay].attacks[0].Name);
            Console.SetCursorPosition(70, 5);
            Console.Write("               ");
            Console.SetCursorPosition(70, 5);
            Console.Write("{0}  ", pokemonsPlayer[pokemonPlay].attacks[1].Name);
            Console.SetCursorPosition(70, 6);
            Console.Write("Cambiar pokemon");
            return Convert.ToInt32(z);

        }

        
    }
    
}
