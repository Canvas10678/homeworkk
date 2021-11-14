using System;
using System.Collections.Generic;

namespace CPU
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ValueInformation> values = new List<ValueInformation>();

            while (true)
            {
                string information = Console.ReadLine();
                if (information == "?")
                {
                    Calculatetion(values);
                    break;
                }
                else
                {
                    values.Add(InputYourInformation(information));
                }
            }
        }
        static ValueInformation InputYourInformation(string Values)
        {
            string[] words = Values.Split(' '); 
            string Intrucion = words[0]; 
            string Data = words[1];

            ValueInformation Value = new ValueInformation();
            Value.Intruction = Intrucion; 
            Value.Data = Data; 
            return Value; 
        }
        static void Calculatetion(List<ValueInformation> values, int count = 0)
        {
            count++;
            List<ValueInformation> WaitforDataInformation = new List<ValueInformation>();
            AxisCPU[] cpu = new AxisCPU[4]; 

            for (int a = 0; a < cpu.Length; a++)
            {
                cpu[a] = new AxisCPU();
            }

            for (int i = 0; i < values.Count; i++)
            {
                string instruct = values[i].Intruction;
                for (int j = 0; j < cpu.Length; j++)
                {
                    if (cpu[j].CPUInstruction == null || cpu[j].CPUInstruction == instruct)
                    {
                        cpu[j].CPUInstruction = instruct;
                        for (int b = 0; b < cpu[j].NewData.Length; b++)
                        {
                            if (cpu[j].NewData[b] == null || cpu[j].NewData[b] == values[i].Data)
                            {
                                cpu[j].NewData[b] = values[i].Data;
                                break;
                            }
                            else if (b == cpu[j].NewData.Length - 1)
                            {
                                WaitforDataInformation.Add(values[i]);
                                break;
                            }
                        }
                        break;
                    }
                    else if (j == cpu.Length - 1)
                    {
                        WaitforDataInformation.Add(values[i]);
                    }
                }
                if (WaitforDataInformation.Count > 0)
                {
                    Calculatetion(WaitforDataInformation, count);
                }
                else
                {
                    Console.WriteLine("CPU cycles needed: " + count);
                }

            }

        }
    }
   
}




