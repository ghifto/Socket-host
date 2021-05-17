using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketClassi
{
    public class InfGiochi
    {
        public static string[,] Tabellone = new string[3, 3]; // 1 = o mentre 2 = x

        public static void Controllo(ref bool vincita, ref string vincitore)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if(Tabellone[i, k] != null)
                    {
                        if (i == 0 && k == 0)
                        {
                            if (Tabellone[i, k] == Tabellone[(i + 1), (k + 1)])
                                if (Tabellone[i, k] == Tabellone[((i + 2)), (k + 2)])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }

                            if (Tabellone[i, k] == Tabellone[i, (k + 1)])
                                if (Tabellone[i, k] == Tabellone[i, (k + 2)])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }

                            if (Tabellone[i, k] == Tabellone[(i + 1), k])
                                if (Tabellone[i, k] == Tabellone[(i + 2), k])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }
                        }
                        else if (i == 0 && k == 1)
                        {
                            if (Tabellone[i, k] == Tabellone[i, (k - 1)])
                                if (Tabellone[i, k] == Tabellone[i, (k + 1)])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }

                            if (Tabellone[i, k] == Tabellone[(i + 1), k])
                                if (Tabellone[i, k] == Tabellone[(i + 2), k])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }
                        }
                        else if (i == 0 && k == 2)
                        {
                            if (Tabellone[i, k] == Tabellone[(i + 1), (k - 1)])
                                if (Tabellone[i, k] == Tabellone[(i + 2), (k + 2)])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }

                            if (Tabellone[i, k] == Tabellone[i, (k - 1)])
                                if (Tabellone[i, k] == Tabellone[i, (k + 2)])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }

                            if (Tabellone[i, k] == Tabellone[(i + 1), k])
                                if (Tabellone[i, k] == Tabellone[(i + 2), k])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }
                        }
                        else if (i == 1 && k == 0)
                        {
                            if (Tabellone[i, k] == Tabellone[(i + 1), k])
                                if (Tabellone[i, k] == Tabellone[(i - 1), k])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }

                            if (Tabellone[i, k] == Tabellone[i, (k + 1)])
                                if (Tabellone[i, k] == Tabellone[i, (k + 2)])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }
                        }
                        else if (i == 1 && k == 1)
                        {
                            if (Tabellone[i, k] == Tabellone[i, (k - 1)])
                                if (Tabellone[i, k] == Tabellone[i, (k + 1)])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }

                            if (Tabellone[i, k] == Tabellone[(i - 1), k])
                                if (Tabellone[i, k] == Tabellone[(i + 1), k])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }

                            if (Tabellone[i, k] == Tabellone[(i - 1), (k - 1)])
                                if (Tabellone[i, k] == Tabellone[(i + 1), (k + 1)])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }

                            if (Tabellone[i, k] == Tabellone[(i - 1), (k + 1)])
                                if (Tabellone[i, k] == Tabellone[(i + 1), (k - 1)])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }
                        }
                        else if (i == 1 & k == 2)
                        {
                            if (Tabellone[i, k] == Tabellone[(i + 1), k])
                                if (Tabellone[i, k] == Tabellone[(i - 1), k])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }

                            if (Tabellone[i, k] == Tabellone[i, (k - 1)])
                                if (Tabellone[i, k] == Tabellone[i, (k + 2)])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }
                        }
                        else if (i == 2 && k == 0)
                        {
                            if (Tabellone[i, k] == Tabellone[(i - 1), (k + 1)])
                                if (Tabellone[i, k] == Tabellone[(i - 2), (k + 2)])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }

                            if (Tabellone[i, k] == Tabellone[i, (k + 1)])
                                if (Tabellone[i, k] == Tabellone[i, (k + 2)])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }

                            if (Tabellone[i, k] == Tabellone[(i - 1), k])
                                if (Tabellone[i, k] == Tabellone[(i - 2), k])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }
                        }
                        else if (i == 2 && k == 1)
                        {
                            if (Tabellone[i, k] == Tabellone[i, (k + 1)])
                                if (Tabellone[i, k] == Tabellone[i, (k + 2)])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }

                            if (Tabellone[i, k] == Tabellone[(i - 1), k])
                                if (Tabellone[i, k] == Tabellone[(i - 2), k])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }
                        }
                        else if (i == 2 && k == 2)
                        {
                            if (Tabellone[i, k] == Tabellone[(i - 1), (k - 1)])
                                if (Tabellone[i, k] == Tabellone[(i - 2), (k + 2)])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }

                            if (Tabellone[i, k] == Tabellone[i, (k - 1)])
                                if (Tabellone[i, k] == Tabellone[i, (k + 2)])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }

                            if (Tabellone[i, k] == Tabellone[(i - 1), k])
                                if (Tabellone[i, k] == Tabellone[(i - 2), k])
                                {
                                    vincita = true;
                                    vincitore = Tabellone[i, k];
                                }
                        }
                    }
                    
                }
            }
        }
    }
}
