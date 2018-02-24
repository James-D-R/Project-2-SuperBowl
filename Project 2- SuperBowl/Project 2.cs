using System;
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
            
            string Filepath = GetFilePath();
            bool value = TestFilePath(Filepath);


            if(value == true)
            {
                StreamReader reader = OpenFile(Filepath);

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
                reader.Close();

                SuperBowl[] SuperBowlObjects = CreateObjects(ListDate, ListSB, ListAttendance, ListQBWinner, ListCoachWinner, ListTeamWinner, ListWinningPts, ListQBLoser,
                                ListCoachLoser, ListTeamLoser, ListLosingPts, ListMVP, ListStadium, ListCity, ListState);

                string[,] WinningStats = SuperBowlWinners(SuperBowlObjects); // Returns muli-dimensional array of SuperBowl winner's stats

                string[,] AttendanceStats = SuperBowlAttendance(SuperBowlObjects);

                string[,] StateStats = SuperBowlStates(SuperBowlObjects);

                string[,] MVPData = SuperBowlMVP(SuperBowlObjects);

                string[] LosingestCoachList = MostLossCoach(SuperBowlObjects);
                string WinningestCoach = MostWinsCoach(SuperBowlObjects);
                string TeamWinStats = TeamMostWins(SuperBowlObjects);
                string LoseTeamStats = TeamMostLoss(SuperBowlObjects);

                int[] GreatestDif = GreatestPointDif(SuperBowlObjects);

                int Average = AverageAttendace(SuperBowlObjects);


                WriteFile(WinningStats, AttendanceStats, StateStats, MVPData, LosingestCoachList, WinningestCoach, TeamWinStats, LoseTeamStats, GreatestDif, Average, SuperBowlObjects, Filepath);

            }



        }// End of Main Method

        static bool TestFilePath(string Filepath)
        {

            bool value = true;
                try
                {
                    Filepath = Filepath + "Super_Bowl_Project.csv";
                    FileStream testfile = new FileStream(@Filepath, FileMode.Open, FileAccess.Read);
                    StreamReader testread = new StreamReader(testfile);
                    testread.Close();
                    testfile.Close();
                }
                catch (Exception i)
                {
                Console.WriteLine(i.Message);
                    Console.WriteLine("Unable to find file path. Please try entering the path again.");
                    Console.ReadLine();
                    value = false;
                }
            return value;
            
            //End of TestFilePath Method
        }

        static StreamReader OpenFile(string Filepath)
        {
            Filepath = Filepath + "Super_Bowl_Project.csv";
            FileStream file;
            StreamReader reader;
            file = new FileStream(@Filepath, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(file);
            return reader;
          
        }// End of OpenFile Method

        static void WriteFile(string[,] WinningStats, string[,] AttendanceStats, string[,] StateStats, string[,] MVPData, 
                                      string[] LosingestCoachList, string WinningestCoach, string TeamWinStats, string LoseTeamStats,
                                      int[] GreatestDif, int Average, SuperBowl[] SuperBowlObjects,string Filepath)
        {
            Filepath = Filepath + "Super_Bowl_Stats.txt";
            FileStream newFile = new FileStream(Filepath, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(newFile);

            writer.WriteLine("______________________________________________");
            writer.WriteLine("Super Bowl Winners Listed..."); //Part 1
            writer.WriteLine("1.Team name");
            writer.WriteLine("2.Year");
            writer.WriteLine("3.Winning QB");
            writer.WriteLine("4.Winning Coach");
            writer.WriteLine("5.MVP");
            writer.WriteLine("6.Winning vs Losing point difference");
            writer.WriteLine("\n");
            for (var i = 0; i < 51; i++)
            {
                writer.WriteLine("1.{0}", WinningStats[i, 0]);
                writer.WriteLine("2.{0}", WinningStats[i, 1]);
                writer.WriteLine("3.{0}", WinningStats[i, 2]);
                writer.WriteLine("4.{0}", WinningStats[i, 3]);
                writer.WriteLine("5.{0}", WinningStats[i, 4]);
                writer.WriteLine("6.{0}", WinningStats[i, 5]);
                writer.WriteLine();

            }
            writer.WriteLine("______________________________________________");
            writer.WriteLine("Top 5 attended Super Bowls..."); //Part 2
            writer.WriteLine("1.Attendance");
            writer.WriteLine("2.Year");
            writer.WriteLine("3.Winning Team");
            writer.WriteLine("4.Losing Team");
            writer.WriteLine("5.City");
            writer.WriteLine("6.State");
            writer.WriteLine("7.Stadium");
            writer.WriteLine("");
            for (var y = 0; y < 5; y++)
            {
                writer.WriteLine("1.{0}", AttendanceStats[y, 0]);
                writer.WriteLine("2.{0}", AttendanceStats[y, 1]);
                writer.WriteLine("3.{0}", AttendanceStats[y, 2]);
                writer.WriteLine("4.{0}", AttendanceStats[y, 3]);
                writer.WriteLine("5.{0}", AttendanceStats[y, 4]);
                writer.WriteLine("6.{0}", AttendanceStats[y, 5]);
                writer.WriteLine("7.{0}", AttendanceStats[y, 6]);
                writer.WriteLine("");
            }
            writer.WriteLine("________________________________________________");
            writer.WriteLine("State that has hosted the most Super Bowls.");//Part 3
            writer.WriteLine("1.City");
            writer.WriteLine("2.State");
            writer.WriteLine("3.Stadium");
            writer.WriteLine("");
            for (int z = 0; z < 15; z++)
            {
                writer.WriteLine("1.{0}", StateStats[z, 0]);
                writer.WriteLine("2.{0}", StateStats[z, 1]);
                writer.WriteLine("3.{0}", StateStats[z, 2]);
                writer.WriteLine();
            }

            writer.WriteLine("__________________________________________________");
            writer.WriteLine("Players who won MVP at least twice.");//Part 4
            writer.WriteLine("1.Name of MVP");
            writer.WriteLine("2.Winning Team");
            writer.WriteLine("3.Losing Team");
            writer.WriteLine("");
            for (int z = 0; z < 11; z++)
            {
                writer.WriteLine("1.{0}", MVPData[z, 0]);
                writer.WriteLine("2.{0}", MVPData[z, 1]);
                writer.WriteLine("3.{0}", MVPData[z, 2]);
                writer.WriteLine();
            }

            writer.WriteLine("__________________________________________________");
            writer.WriteLine("Miscellaneous Stats"); //Part 5
            writer.WriteLine("");
            writer.WriteLine("");
            writer.WriteLine("Coaches with the most Super Bowl losses:");
            for (int i = 0; i < LosingestCoachList.Length; i++)
            {
                writer.WriteLine(LosingestCoachList[i]);
            }
            writer.WriteLine("");
            writer.WriteLine("Coach with most Super Bowl wins: {0}", WinningestCoach);
            writer.WriteLine("");
            writer.WriteLine("Team with the most Super Bowl wins: {0}", TeamWinStats);
            writer.WriteLine("");
            writer.WriteLine("Team with the most Super Bowl losses: {0}", LoseTeamStats);
            writer.WriteLine("");
            for (int i = 0; i < GreatestDif.Length; i++)
            {
                writer.WriteLine("Game with greatest point difference is SuperBowl {0}", SuperBowlObjects[GreatestDif[i]].SB);
                writer.WriteLine("The point difference was {0} points.", SuperBowlObjects[GreatestDif[i]].WinningPts - SuperBowlObjects[GreatestDif[i]].LosingPts);
            }
            writer.WriteLine("");
            writer.WriteLine("The average Super Bowl attendance is {0}", Average);

            writer.Close();
            newFile.Close();

            return;

        }//End of WriteFile Method

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

        static string GetFilePath()
        {
            string Filepath;
            Console.WriteLine("Please enter the Filepath where the file 'Super_Bowl_Project.csv' will be read from.\nThe new file will also be writen here.");
            Console.WriteLine("*Do not include 'Super_Bowl_Project.csv' at the end of your entered filepath");
            Console.WriteLine("Example: C:/Users/remjamd/Documents/");
            Filepath = Console.ReadLine();
            
            return Filepath;

        }//End of GetFilePath Method

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


        static string[] MostLossCoach(SuperBowl[] SuperBowlObjects)
        {
            string LosingestCoach = "";
            IEnumerable<SuperBowl> SuperBowlQuery =
                from superBowls in SuperBowlObjects
                orderby superBowls.CoachLoser ascending
                select superBowls;

            string[] C = { };
            foreach (SuperBowl superBowls in SuperBowlQuery)
            {
                string[] a = { superBowls.CoachLoser };
                C = C.Concat(a).ToArray();
            }
            int lastgreatest = 0;
            var g = C.GroupBy(i => i); // From Stackoverflow

            string[] LosingestCoachList = { };
            foreach (var grp in g)
            {
               // Console.WriteLine("{0} {1}", grp.Key, grp.Count());
                int Losses = grp.Count();
                if (Losses >= 4)
                {
                    LosingestCoach = grp.Key;
                    string[] temp = { LosingestCoach };
                    LosingestCoachList = LosingestCoachList.Concat(temp).ToArray();
                    lastgreatest = grp.Count();
                }
            }
                return LosingestCoachList;
        }//End of MostLossCoach Method


        static string MostWinsCoach(SuperBowl[] SuperBowlObjects)
        {
            string WinningestCoach = "";
            IEnumerable<SuperBowl> SuperBowlQuery =
                from superBowls in SuperBowlObjects
                orderby superBowls.CoachWinner ascending
                select superBowls;

            string[] C = { };
            foreach(SuperBowl superBowls in SuperBowlQuery)
            {
                string[] a = { superBowls.CoachWinner };
                C = C.Concat(a).ToArray();
            }
            int lastgreatest = 0;
            var g = C.GroupBy(i => i); // From Stackoverflow

            foreach (var grp in g)
            {
                int wins = grp.Count();
                if( wins >= lastgreatest)
                {
                    WinningestCoach = grp.Key;
                    lastgreatest = grp.Count();
                }

            }
                return WinningestCoach;
            
        }//End of MostWinsCoach Method

        static string TeamMostWins(SuperBowl[] SuperBowlObjects)
        {
            string TeamWinStats = "";
            string[] C = { };
            IEnumerable<SuperBowl> SuperBowlQuery =
                from superBowls in SuperBowlObjects
                orderby superBowls.WinningTeam ascending
                select superBowls;

            
            foreach (SuperBowl superBowls in SuperBowlQuery)
            {
               // Console.WriteLine(superBowls.WinningTeam);
                string[] a = { superBowls.WinningTeam };
                C = C.Concat(a).ToArray();
            }
            var g = C.GroupBy(i => i); // From Stackoverflow

            int lastgreatest = 0;
            foreach (var grp in g)
            {
                //Console.WriteLine("{0} {1}", grp.Key, grp.Count());
                int wins = grp.Count();
                if (wins > lastgreatest)
                {
                    TeamWinStats = grp.Key;
                    lastgreatest = grp.Count();
                }
            }

                return TeamWinStats;
            //End of TeamMostWins Method
        }
        static string TeamMostLoss(SuperBowl[] SuperBowlObjects)
        {
            string LoseTeamStats = "";

            string[] C = { };
            IEnumerable<SuperBowl> SuperBowlQuery =
                from superBowls in SuperBowlObjects
                orderby superBowls.LosingTeam ascending
                select superBowls;


            foreach (SuperBowl superBowls in SuperBowlQuery)
            {
                // Console.WriteLine(superBowls.WinningTeam);
                string[] a = { superBowls.LosingTeam };
                C = C.Concat(a).ToArray();
            }
            var g = C.GroupBy(i => i); // From Stackoverflow

            int lastgreatest = 0;
            foreach (var grp in g)
            {
               // Console.WriteLine("{0} {1}", grp.Key, grp.Count());
                int Losses = grp.Count();
                if (Losses > lastgreatest)
                {
                    LoseTeamStats = grp.Key;
                    lastgreatest = grp.Count();
                }
            }

            return LoseTeamStats;
        }
        //End of TeamMostLoss Method

        static int[] GreatestPointDif(SuperBowl[] SuperBowlObjects)
        {
            int[] GreatestDif = { };
            int[] PointList = { };
            for (int i = 0; i < 51; i++)
            {
                int PointDif;
                PointDif = SuperBowlObjects[i].WinningPts - SuperBowlObjects[i].LosingPts;
                int[] a = { PointDif};
                PointList = PointList.Concat(a).ToArray();

            }
           
            int lastgreatest = 0;
            for (int x = 0; x < 51; x++)
            {
                if (PointList[x] > lastgreatest)
                {
                    lastgreatest = PointList[x];
                }
            }
            int greatestDif = lastgreatest;
            for (int y =0; y < 51; y++)
            {
                if(PointList[y] ==  greatestDif)
                {
                    int[] SBnumber = { y};
                    GreatestDif = GreatestDif.Concat(SBnumber).ToArray();

                }
            }
            
            
            return GreatestDif;

        }//End of GreatestPointDif Method

        static int AverageAttendace(SuperBowl[] SuperBowlObjects)
        {
            int TotalAttendaces = 0;
            int Average;
            for (int x = 0; x < SuperBowlObjects.Length; x++)
            {
                TotalAttendaces = TotalAttendaces + SuperBowlObjects[x].Attendance;
            }

            Average = TotalAttendaces / SuperBowlObjects.Length;
            return Average;
        }//End of AverageAttendace Method
    } 
    

    
}
