﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2__SuperBowl
{
    class SuperBowl
    {
        public string Date { get; set; }
        public string SB { get; set; }
        public int Attendance { get; set; }
        public string QBWinner { get; set; }
        public string CoachWinner { get; set; }
        public string WinningTeam { get; set; }
        public int WinningPts { get; set; }
        public string QBLoser { get; set; }
        public string CoachLoser { get; set; }
        public string LosingTeam { get; set; }
        public int LosingPts { get; set; }
        public string MVP { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public SuperBowl(int pos, 
                        string[] ListDate,
                        string[] ListSB,
                        int[] ListAttendance,
                        string[] ListQBWinner,
                        string[] ListCoachWinner,
                        string[] ListTeamWinner,
                        int[] ListWinningPts,
                        string[] ListQBLoser,
                        string[] ListCoachLoser,
                        string[] ListTeamLoser,
                        int[] ListLosingPts,
                        string[] ListMVP,
                        string[] ListStadium,
                        string[] ListCity,
                        string[] ListState)
        {
            Date = ListDate[pos];
            SB = ListSB[pos];
            Attendance = ListAttendance[pos];
            QBWinner = ListQBWinner[pos];
            CoachWinner = ListCoachWinner[pos];
            WinningTeam = ListTeamWinner[pos];
            WinningPts = ListWinningPts[pos];
            QBLoser = ListQBLoser[pos];
            CoachLoser = ListCoachLoser[pos];
            LosingTeam = ListTeamLoser[pos];
            LosingPts = ListLosingPts[pos];
            MVP = ListMVP[pos];
            Stadium = ListStadium[pos];
            City = ListCity[pos];
            State = ListState[pos];

        }
        

        static void Main(string[] args)
        {
            StreamReader reader = OpenFile();

            string[] ListDate = { };
            string[] ListSB = { };
            int[] ListAttendance = { };
            string[] ListQBWinner = { };
            string[] ListCoachWinner = { };
            string[] ListTeamWinner = { };
            int[] ListWinningPts = { };
            string[] ListQBLoser = { };
            string[] ListCoachLoser = { };
            string[] ListTeamLoser = { };
            int[] ListLosingPts = { };
            string[] ListMVP = { };
            string[] ListStadium = { };
            string[] ListCity = { };
            string[] ListState = { };

            string[] row;
            reader.ReadLine();
            for (var z = 0; z < 51; z++)
            {
                char delimiter = ',';
                row = reader.ReadLine().Split(delimiter);

                string[] a = { row[0] };
                ListDate = ListDate.Concat(a).ToArray();

                string[] b = { row[1] };
                ListSB = ListSB.Concat(b).ToArray();

                int[] c = { Int32.Parse(row[2]) };
                ListAttendance = ListAttendance.Concat(c).ToArray();

                string[] d = { row[3] };
                ListQBWinner = ListQBWinner.Concat(d).ToArray();

                string[] e = { row[4] };
                ListCoachWinner = ListCoachWinner.Concat(e).ToArray();

                string[] f = { row[5] };
                ListTeamWinner = ListTeamWinner.Concat(f).ToArray();

                int[] g = { Int32.Parse(row[6]) };
                ListWinningPts = ListWinningPts.Concat(g).ToArray();

                string[] h = { row[7] };
                ListQBLoser = ListQBLoser.Concat(h).ToArray();

                string[] i = { row[8] };
                ListCoachLoser = ListCoachLoser.Concat(i).ToArray();

                string[] j = { row[9] };
                ListTeamLoser = ListTeamLoser.Concat(j).ToArray();

                int[] k = { Int32.Parse(row[10]) };
                ListLosingPts = ListLosingPts.Concat(k).ToArray();

                string[] l = { row[11] };
                ListMVP = ListMVP.Concat(l).ToArray();

                string[] m = { row[12] };
                ListStadium = ListStadium.Concat(m).ToArray();

                string[] n = { row[13] };
                ListCity = ListCity.Concat(n).ToArray();

                string[] o = { row[14] };
                ListState = ListState.Concat(o).ToArray();
            }

            SuperBowl[] SuperBowlObjects = CreateObjects(ListDate, ListSB, ListAttendance, ListQBWinner, ListCoachWinner, ListTeamWinner, ListWinningPts, ListQBLoser,
                            ListCoachLoser, ListTeamLoser, ListLosingPts, ListMVP, ListStadium, ListCity, ListState);

            string[,] WinningStats = SuperBowlWinners(SuperBowlObjects); // Returns muli-dimensional array of SuperBowl winner's stats
            
            for (var i = 0; i < 51; i++)
            {
                Console.WriteLine("1.{0}", WinningStats[i, 0]);
                Console.WriteLine("2.{0}", WinningStats[i, 1]);
                Console.WriteLine("3.{0}", WinningStats[i, 2]);
                Console.WriteLine("4.{0}", WinningStats[i, 3]);
                Console.WriteLine("5.{0}", WinningStats[i, 4]);
                Console.WriteLine("6.{0}", WinningStats[i, 5]);
                Console.WriteLine();

            }
            Console.WriteLine("Press enter to clear...");
            Console.ReadLine();
            Console.Clear();

            string[,] AttendanceStats = SuperBowlAttendance(SuperBowlObjects);

            for (var y = 0; y < 5; y++)
            {
                Console.WriteLine("1.{0}", AttendanceStats[y, 0]);
                Console.WriteLine("2.{0}", AttendanceStats[y, 1]);
                Console.WriteLine("3.{0}", AttendanceStats[y, 2]);
                Console.WriteLine("4.{0}", AttendanceStats[y, 3]);
                Console.WriteLine("5.{0}", AttendanceStats[y, 4]);
                Console.WriteLine("6.{0}", AttendanceStats[y, 5]);
                Console.WriteLine("7.{0}", AttendanceStats[y, 6]);
                Console.WriteLine();
            }
            Console.WriteLine("Press enter to clear...");
            Console.ReadLine();
            Console.Clear();

            string[,] StateStats = SuperBowlStates(SuperBowlObjects);

            for (int z= 0; z < 15; z++)
            {
                Console.WriteLine("1.{0}", StateStats[z, 0]);
                Console.WriteLine("2.{0}", StateStats[z,1]);
                Console.WriteLine("3.{0}", StateStats[z, 2]);
                Console.WriteLine();
            }
            Console.WriteLine("Press enter to clear...");
            Console.ReadLine();
            Console.Clear();

            string[,] MVPData = SuperBowlMVP(SuperBowlObjects);
            for (int z = 0; z < 11; z++)
            {
                Console.WriteLine("1.{0}", MVPData[z, 0]);
                Console.WriteLine("2.{0}", MVPData[z, 1]);
                Console.WriteLine("3.{0}", MVPData[z, 2]);
                Console.WriteLine();
            }

            Console.WriteLine("Press enter to clear...");
            Console.ReadLine();
            Console.Clear();

            //Console.WriteLine(SuperBowlObjects[1].SB);



        }// End of Main Method

        static StreamReader OpenFile()
        {
            FileStream file = new FileStream("Super_Bowl_Project.csv", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            return reader;
        }// End of OpenFile Method

        static SuperBowl[] CreateObjects(string[] ListDate, string[] ListSB, int[] ListAttendance, string[] ListQBWinner,
                                         string[] ListCoachWinner, string[] ListTeamWinner, int[] ListWinningPts, string[] ListQBLoser,
                                         string[] ListCoachLoser, string[] ListTeamLoser, int[] ListLosingPts, string[] ListMVP,
                                         string[] ListStadium, string[] ListCity, string[] ListState)
        {
            SuperBowl[] SuperBowlObjects = new SuperBowl[51]; //Create a list of Superbowl objects
            for (int x = 0; x < 51; x++)
            {

                SuperBowlObjects[x] = new SuperBowl(x, ListDate, ListSB, ListAttendance, ListQBWinner, ListCoachWinner, ListTeamWinner, ListWinningPts, ListQBLoser,
                            ListCoachLoser, ListTeamLoser, ListLosingPts, ListMVP, ListStadium, ListCity, ListState);
            };
            return SuperBowlObjects;
        }// End of CreateObjects Method

        static string[,] SuperBowlWinners(SuperBowl[] SuperBowlObjects)
        {
            string[,] WinningStats = new string[51, 6];
            for (int x = 0; x < SuperBowlObjects.Length; x++)
            {
                string year = SuperBowlObjects[x].Date;
                int yearLength = year.Length;
                int last = yearLength - 1;
                int first = yearLength - 2;
                string firstStr = year[first].ToString();
                string lastStr = year[last].ToString();
                string yearAbrv = "'" + firstStr + lastStr;
                int PointDif = SuperBowlObjects[x].WinningPts - SuperBowlObjects[x].LosingPts;
                string PointDifStr = PointDif.ToString();

                string[] Single = {SuperBowlObjects[x].WinningTeam, yearAbrv, SuperBowlObjects[x].QBWinner, SuperBowlObjects[x].CoachWinner,SuperBowlObjects[x].MVP, PointDifStr};
                WinningStats[x, 0] = SuperBowlObjects[x].WinningTeam;
                WinningStats[x, 1] = yearAbrv;
                WinningStats[x, 2] = SuperBowlObjects[x].QBWinner;
                WinningStats[x, 3] = SuperBowlObjects[x].CoachWinner;
                WinningStats[x, 4] = SuperBowlObjects[x].MVP;
                WinningStats[x, 5] = PointDifStr;

                
            }
            return WinningStats;
        }// End of SuperBowlWinners Method

        static string[,] SuperBowlAttendance(SuperBowl[] SuperBowlObjects)
        {
            string[,] AttendanceStats = new string[5, 7];

            IEnumerable<SuperBowl> SuperBowlQuery =
                from superBowls in SuperBowlObjects
                where superBowls.Attendance > 100000
                orderby superBowls.Attendance descending
                select superBowls;

            int x = 0;
            foreach (SuperBowl superBowls in SuperBowlQuery)
            {
                string num = superBowls.Attendance.ToString();
                AttendanceStats[x, 0] = num;

                string year = superBowls.Date;
                int yearLength = year.Length;
                int last = yearLength - 1;
                int first = yearLength - 2;
                string firstStr = year[first].ToString();
                string lastStr = year[last].ToString();
                string yearAbrv = "'" + firstStr + lastStr;

                AttendanceStats[x, 1] = yearAbrv;
                AttendanceStats[x, 2] = superBowls.WinningTeam;
                AttendanceStats[x, 3] = superBowls.LosingTeam;
                AttendanceStats[x, 4] = superBowls.City;
                AttendanceStats[x, 5] = superBowls.State;
                AttendanceStats[x, 6] = superBowls.Stadium;
                x++;
            }
            return AttendanceStats;
        }//End of SuperBowlAttendance Method

        static string[,] SuperBowlStates(SuperBowl[] SuperBowlObjects)
        {
            string[,] StateStats = new string[15, 3];
            IEnumerable<SuperBowl> SuperBowlQuery =
                from superBowls in SuperBowlObjects
                where superBowls.State == "Florida"
                orderby superBowls.State ascending
                select superBowls;
            int x = 0;
            foreach (SuperBowl superBowls in SuperBowlQuery)
            {
                StateStats[x, 0] = superBowls.City;
                StateStats[x, 1] = superBowls.State;
                StateStats[x, 2] = superBowls.Stadium;
                x++;
            }
            return StateStats;
        }//End of SuperBowlStates Method

        static string[,] SuperBowlMVP(SuperBowl[] SuperBowlObjects)
        {
            string[,] MVPData = new string[11,3];
            IEnumerable<SuperBowl> SuperBowlQuery =
                from superBowls in SuperBowlObjects
                orderby superBowls.MVP ascending
                select superBowls;
            string[] MVPs = { };
            string[] temp = { };
            int x = 0;

            foreach( SuperBowl superBowls in SuperBowlQuery)
            {
                
                if ( superBowls.MVP == "Eli Manning")
                {
                    MVPData[x, 0] = superBowls.MVP;
                    MVPData[x, 1] = superBowls.WinningTeam;
                    MVPData[x, 2] = superBowls.LosingTeam;
                    x++;
                    
                }
                if (superBowls.MVP == "Joe Montana")
                {
                    MVPData[x, 0] = superBowls.MVP;
                    MVPData[x, 1] = superBowls.WinningTeam;
                    MVPData[x, 2] = superBowls.LosingTeam;
                    x++;
                }
                if (superBowls.MVP == "Terry Bradshaw")
                {
                    MVPData[x, 0] = superBowls.MVP;
                    MVPData[x, 1] = superBowls.WinningTeam;
                    MVPData[x, 2] = superBowls.LosingTeam;
                    x++;
                }
                if (superBowls.MVP == "Tom Brady")
                {
                    MVPData[x, 0] = superBowls.MVP;
                    MVPData[x, 1] = superBowls.WinningTeam;
                    MVPData[x, 2] = superBowls.LosingTeam;
                    x++;
                }
                else
                {

                }
                
            }return MVPData;
            //End of SuperBowl MVP Method

            
            
            
            
                
                
             
                

                
            
            

              
        }

    }
}
