/*
  GROUP MEMBERS BBIT 4A:
1. 110355 - Diana Kalema
2. 112451 - Richard Gachiri Muriithi
3. 113532 - Keith Pere
4. 114159 - Robert Wainaina
 

 */ 

using System;
using System.Collections.Generic;

namespace Einstein_Riddle
{
    public enum Color { Blue =1, Green, Red, White, Yellow };
    public enum Nationality { Brit=1, Dane, German, Norwegian, Swede};
    public enum Drink { Coffee=1, Milk, Beer, Tea, Water };
    public enum Cigarette { PallMall=1, Dunhill, Blend, BlueMaster, Prince};
    public enum Pet { Dogs=1, Cats, Birds, Horse, Fish}

    class Program
    {
        static void Main(string[] args)
        {
            DateTime begin = DateTime.Now;
            string positions ="12345"; // 1 There are five houses
            string[] combs = Combinations(positions);
            int solutions = 0;

            for (int nat = 0; nat < combs.Length; nat++)
            {
                if (Check_Requirement(10, combs[nat]))
                {
                    for (int hou = 0; hou < combs.Length; hou++)
                    {
                        if ((Check_Requirement(2, combs[nat], combs[hou]) == true) &&
                            (Check_Requirement(6, combs[nat], combs[hou]) == true) &&
                            (Check_Requirement(15, combs[nat], combs[hou]) == true))
                        {
                            for (int dri = 0; dri < combs.Length; dri++)
                            {
                                if ((Check_Requirement(4, combs[nat], combs[hou], combs[dri]) == true) &&
                                    (Check_Requirement(5, combs[nat], combs[hou], combs[dri]) == true) &&
                                    (Check_Requirement(9, combs[nat], combs[hou], combs[dri]) == true))
                                    for (int cig = 0; cig < combs.Length; cig++)
                                    {
                                        if ((Check_Requirement(8, combs[nat], combs[hou], combs[dri], combs[cig]) == true) &&
                                            (Check_Requirement(13, combs[nat], combs[hou], combs[dri], combs[cig]) == true) &&
                                            (Check_Requirement(14, combs[nat], combs[hou], combs[dri], combs[cig]) == true))
                                        {
                                            for (int pet = 0; pet < combs.Length; pet++)
                                            {
                                                if ((Check_Requirement(3, combs[nat], combs[hou], combs[dri], combs[cig], combs[pet]) == true) &&
                                                    (Check_Requirement(7, combs[nat], combs[hou], combs[dri], combs[cig], combs[pet]) == true) &&
                                                    (Check_Requirement(11, combs[nat], combs[hou], combs[dri], combs[cig], combs[pet]) == true) &&
                                                    (Check_Requirement(12, combs[nat], combs[hou], combs[dri], combs[cig], combs[pet]) == true))
                                                {
                                                    solutions = solutions + 1;
                                                    Display_Results(solutions, combs[nat], combs[hou], combs[dri], combs[cig], combs[pet]);
                                                }
                                            }
                                        }
                                    }
                            }
                        }
                    }
                }
            }

            DateTime end = DateTime.Now;
            double diff = (end - begin).TotalMilliseconds;
            Console.WriteLine("Solved in " + diff.ToString() + "milliseconds");
            Console.ReadKey();
        }

        public static bool Check_Requirement(int number, string nat, string hou = "", string dri = "", string cig = "", string pet = "")
        {
            switch (number)
            {

                case 2: // The Brit lives in the red house
                    if (nat.Substring(hou.IndexOf(((int)Color.Red).ToString()), 1) == ((int)Nationality.Brit).ToString())
                    {
                        return true;
                    }
                    break;
                case 3: // The Swede own the dog
                    if (nat.Substring(pet.IndexOf(((int)Pet.Dogs).ToString()), 1) == ((int)Nationality.Swede).ToString())
                    {
                        return true;
                    }
                    break;
                case 4: // The Green house owner drinks coffee
                    if (dri.Substring(hou.IndexOf(((int)Color.Green).ToString()), 1) == ((int)Drink.Coffee).ToString())
                    {
                        return true;
                    }
                    break;

                case 5: // The Dane drinks tea
                    if (dri.Substring(nat.IndexOf(((int)Nationality.Dane).ToString()), 1) == ((int)Drink.Tea).ToString())
                    {
                        return true;
                    }
                    break;
                case 6: // The greem house is to the left of the white house
                    if (hou.IndexOf(((int)Color.Green).ToString()) - hou.IndexOf(((int)Color.White).ToString()) == 1)
                    {
                        return true;
                    }
                    break;
                case 7: // The person who smokes Pall Mall rears birds house
                    if (cig.Substring(pet.IndexOf(((int)Pet.Birds).ToString()), 1) == ((int)Cigarette.PallMall).ToString())
                    {
                        return true;
                    }
                    break;
                case 8: // The owner of the yellow house smokes Dunhill
                    if (cig.Substring(hou.IndexOf(((int)Color.Yellow).ToString()), 1) == ((int)Cigarette.Dunhill).ToString())
                    {
                        return true;
                    }
                    break;
                case 9: // The man living in the center house dirnk milk 
                    if (dri.Substring(2, 1) == ((int)Drink.Milk).ToString())
                    {
                        return true;
                    }
                    break;
                case 10: // The Norwegian lives in the first house
                    if (nat.Substring(0, 1) == ((int)Nationality.Norwegian).ToString())
                    {
                        return true;
                    }
                    break;
                case 11: // The man who smoke blends lives next to the one who keeps cats
                    if (Math.Abs(cig.IndexOf(((int)Cigarette.Blend).ToString()) - pet.IndexOf(((int)Pet.Cats).ToString())) == 1)
                    {
                        return true;
                    }
                    break;
                case 12: // The man who keeps horses lives next to the man who smokes dunhilll
                    if (Math.Abs(pet.IndexOf(((int)Pet.Horse).ToString()) - cig.IndexOf(((int)Cigarette.Dunhill).ToString())) == 1)
                    {
                        return true;
                    }
                    break;
                case 13: // The owner who smokes bluemaster 
                    if (cig.Substring(dri.IndexOf(((int)Drink.Beer).ToString()), 1) == ((int)Cigarette.BlueMaster).ToString())
                    {
                        return true;
                    }
                    break;
                case 14: // The Green smokes Prince
                    if (cig.Substring(nat.IndexOf(((int)Nationality.German).ToString()), 1) == ((int)Cigarette.Prince).ToString())
                    {
                        return true;
                    }
                    break;
                case 15: // The Nowergian lives next to the blues house
                    if (Math.Abs(hou.IndexOf(((int)Color.Blue).ToString()) - nat.IndexOf(((int)Nationality.Norwegian).ToString())) == 1)
                    {
                        return true;
                    }
                    break;
                case 16: // the man who smokes blends has neighbour who drinks water
                    if (Math.Abs(dri.IndexOf(((int)Drink.Water).ToString()) - cig.IndexOf(((int)Cigarette.Blend).ToString())) == 1)
                    {
                        return true;
                    }
                    break;



                default:
                    break;
            }
            return false;
        }

        public static void Display_Results(int solution, string nationality, string color, string drink, string cigarette, string pet)
        {
            Console.WriteLine("SOLUTION" + solution.ToString());
            Console.WriteLine();
            Console.Write(string.Format("{0,-1} | ", "House"));
            Console.Write(string.Format("{0,-6} | ", "COLOR"));
            Console.Write(string.Format("{0,-11}|", "NATIONALITY"));
            Console.Write(string.Format("{0,-12}| ", "DRINK"));
            Console.Write(string.Format("{0,-12}| ", "CIGARETTE"));
            Console.Write(string.Format("{0,-6} | ", "PET"));
            Console.WriteLine();

            for (int c = 0; c < color.Length; c++)
            {
                Console.Write(string.Format("{0,-1} | ", (c + 1)));
                Console.Write(string.Format("{0,-6} | ", ((Color)Convert.ToInt32(color.Substring(c, 1))).ToString()));
                Console.Write(string.Format("{0,-11}|", ((Nationality)Convert.ToInt32(nationality.Substring(c, 1))).ToString()));
                Console.Write(string.Format("{0,-12}| ", ((Drink)Convert.ToInt32(drink.Substring(c, 1))).ToString()));
                Console.Write(string.Format("{0,-12}| ", ((Cigarette)Convert.ToInt32(cigarette.Substring(c, 1))).ToString()));
                Console.WriteLine(string.Format("{0,-6} | ", ((Pet)Convert.ToInt32(pet.Substring(c, 1))).ToString()));
            }

            Console.WriteLine();
        }
        public static string[] Combinations(string positions)
        {
            List<string> combs = new List<string>();
            for (int c = 0; c < positions.Length; c++) 
            {
                string single = positions.Substring(c, 1);
                if (combs.Count == 0)
                {
                    combs.Add(single);
                }
                else
                {
                    List<string> newcombs = new List<string>();
                    for (int current = 0; current < combs.Count; current ++)
                    {
                        for (int pos = 0; pos < combs[current].Length; pos++)
                        {
                            newcombs.Add(combs[current].Substring(0, pos) + single + combs[current].Substring(pos));
                        }
                        newcombs.Add(combs[current] + single);
                    }
                     combs = newcombs;
                }
            }
            return combs.ToArray();
        }
    }
}
