using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomPinGenerator
{
    public class RandomPinGeneratorLibrary
    {
        public static List<int> BatchOfPinCodes()
        {
            try
            {
                List<int> batch = new List<int>();
                int i = 0, size = 0;

                while(size<1000)
                {
                    int randomPin = RandomPinGenerator();
                    if(randomPin != 0 && !batch.Contains(randomPin))
                    {
                        batch.Add(randomPin);
                    }
                    size = batch.Count;

                    i++;
                }

                return batch;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                List<int> batchException = new List<int>();
                return batchException;
            }
            
        }

        public static int RandomPinGenerator()
        {
            try
            {
                Random random = new Random();
                int randomNumber = random.Next(1000, 9999);
                char[] generatedPinString = randomNumber.ToString().ToCharArray();
                int[] generatedPin = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    generatedPin[i] = int.Parse(generatedPinString[i].ToString());
                }

                if (ValidatePinDigits(generatedPin))
                {
                    return int.Parse(string.Join("", generatedPin));
                }
                else
                {
                    return RandomPinGenerator();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }

        }

        public static bool ValidatePinDigits(int[] generatedPin)
        {
            try
            {
                bool flag = true;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = i + 1; j < 4; j++)
                    {
                        if (generatedPin[i] == generatedPin[j])
                        {
                            flag = false;
                            break;
                        }

                        if (j != 3)
                        {
                            for (int k = j + 1; k < 4; k++)
                            {
                                if ((generatedPin[j] == generatedPin[i] + 1) && (generatedPin[k] == generatedPin[j] + 1))
                                {
                                    flag = false;
                                    break;
                                }
                            }

                        }
                    }
                }

                return flag;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            
        }


    }
}
