using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;
using DiskCardGame;
using SavedVars = MagnificusMod.SaveVariables;
using Random = UnityEngine.Random;
namespace MagnificusMod
{
    public class RoomGen : RoomGenRooms
    {

        public static List<List<string>> generateMapId(string room)
        {
            string ids = "";
            List<List<string>> id2 = new List<List<string>>
            {
                new List<string>()
            };
            string lastChar = "null";

            int limit = (room != "goobert") ? 4 : 3;

            int seperatePart = Random.RandomRangeInt(1, limit);
            int seperatePartX = Random.RandomRangeInt(1, 3);

            switch (room)
            {
                case "goobert":

                    for (int y = 0; y < limit; y++)
                    {
                        for (int x = 0; x < 5 + Random.RandomRangeInt(-1, 1); x++)
                        {
                            if (y == seperatePart && Random.RandomRangeInt(0, 100) > 62 || x == seperatePartX && Random.RandomRangeInt(0, 100) > 35) { lastChar = "-"; id2[y].Add("-");continue; }
                            
                            if (lastChar == "/" && Random.Range(0, 100) > 55)
                            {
                                lastChar = "-";
                                id2[y].Add("-");
                                continue;
                            } else if (Random.Range(0, 100) > 55 && y > 1)
                            {
                                lastChar = "-";
                                id2[y].Add("-");
                                continue;
                            }
                            int room2add = Random.Range(1, GooRooms.Count);
                            while (room2add.ToString() == lastChar)
                            {
                                room2add = Random.Range(1, GooRooms.Count);
                            }
                            lastChar = room2add.ToString();
                            string room2add2 = room2add.ToString();
                            if (Random.RandomRangeInt(0, 100) > 81 + ( y * 2))
                            {
                                room2add2 += "bl";
                            }
                            id2[y].Add(room2add2);
                        }
                        if (y != limit - 1)
                        {
                            id2.Add(new List<string>());
                        }
                    }
                    break;
                case "espeara":
                    for (int y = 0; y < limit; y++)
                    {
                        for (int x = 0; x < 5 + Random.RandomRangeInt(-1, 1); x++)
                        {
                            if (y == seperatePart && Random.RandomRangeInt(0, 100) > 35 || x == seperatePartX) { lastChar = "-"; id2[y].Add("-"); continue; }

                            if (lastChar == "/" && Random.Range(0, 100) > 55)
                            {
                                lastChar = "-";
                                id2[y].Add("-");
                                continue;
                            }
                            else if (Random.Range(0, 100) > 55 && y > 1)
                            {
                                lastChar = "-";
                                id2[y].Add("-");
                                continue;
                            }
                            int room2add = Random.Range(1, LavaRooms.Count);
                            while (room2add.ToString() == lastChar)
                            {
                                room2add = Random.Range(1, LavaRooms.Count);
                            }
                            lastChar = room2add.ToString();
                            string room2add2 = room2add.ToString();
                            if (Random.RandomRangeInt(0, 100) > 83 + (y * 2))
                            {
                                room2add2 += "bl";
                            }
                            id2[y].Add(room2add2);
                        }
                        if (y != limit - 1)
                        {
                            id2.Add(new List<string>());
                        }
                    }
                    break;
                case "lonely":
                    for (int y = 0; y < limit; y++)
                    {
                        for (int x = 0; x < 5 + Random.Range(-1, 0); x++)
                        {
                            if (y == seperatePart && Random.RandomRangeInt(0, 100) > 25 || x == seperatePartX) { lastChar = "-"; id2[y].Add("-"); continue; }

                            if (lastChar == "/" && Random.Range(0, 100) > 55)
                            {
                                lastChar = "-";
                                id2[y].Add("-");
                                continue;
                            }
                            else if (Random.Range(0, 100) > 55 && y > 1)
                            {
                                lastChar = "-";
                                id2[y].Add("-");
                                continue;
                            }
                            int room2add = Random.Range(1, VoidRooms.Count);
                            while (room2add.ToString() == lastChar)
                            {
                                room2add = Random.Range(1, VoidRooms.Count);
                            }
                            lastChar = room2add.ToString();
                            string room2add2 = room2add.ToString();
                            if (Random.RandomRangeInt(0, 100) > 86 + (y * 2))
                            {
                                room2add2 += "bl";
                            }
                            id2[y].Add(room2add2);
                        }
                        if (y != limit - 1)
                        {
                            id2.Add(new List<string>());
                        }
                    }
                    break;
            }

            if (Random.Range(0, 100) > 51)//make spawn (also messy)
            {
                List<string> lastRow = id2[id2.Count - 1];
                if (lastRow[lastRow.Count - 1] != "-")
                {
                    id2[id2.Count - 1].Add("0");
                }
                else
                {
                    id2[id2.Count - 1][id2[id2.Count - 1].Count - 1] = "0";
                }
            } else
            {
                List<string> lastRow = id2[id2.Count - 1];
                int spawnLoc = Random.Range(0, lastRow.Count);
                if (room == "espeara")
                {
                    spawnLoc = lastRow.Count - 1;
                }
                if (id2[id2.Count - 1][spawnLoc] != "-")
                {
                    int lastestRow = id2.Count;
                    id2.Add(new List<string>());
                    for (int i = 0; i < lastRow.Count; i++)
                    {
                         id2[lastestRow].Add((i != spawnLoc) ? "-" : "0");
                    }
                } else
                {
                    id2[id2.Count - 1][spawnLoc] = "0";
                }
            }

            if (Random.Range(0, 100) > 51)//append shop (not that messy ( i think ))
            {
                List<string> shopRow = id2[id2.Count - 2];
                int randomThing = Random.RandomRangeInt(0, shopRow.Count);
                id2[id2.Count - 2][randomThing] = "s";
            }
            else
            {
                List<string> shopRow = id2[id2.Count - 2];
                if (shopRow[shopRow.Count - 1] == "-") 
                {
                    shopRow[shopRow.Count - 1] = "s";
                } 
                else 
                {
                    shopRow.Add("s");
                }
            }

            bool hasEdaxio = false;

            if (room == "espeara")
            {
                foreach(CardInfo card in RunState.Run.playerDeck.Cards)
                {
                    if (card.name == "mag_edaxiolegs")
                    {
                        hasEdaxio = true;
                    }
                }
            }
            if (room == "lonely")
            {
                foreach (CardInfo card in RunState.Run.playerDeck.Cards)
                {
                    if (card.name == "mag_edaxiotorso")
                    {
                        hasEdaxio = true;
                    }
                }
            }


            List<string> firstRow = id2[0];//make boss room (not messy)
            List<string> newRow = new List<string>();
            int theBoss = Random.RandomRangeInt(1, firstRow.Count);
            while (firstRow[theBoss] == "-" || firstRow[theBoss] == "e")
            {
                theBoss = Random.RandomRangeInt(1, firstRow.Count);
            }
            if (room == "goobert")
            {
                for (int i = 0; i < firstRow.Count; i++)
                {
                   newRow.Add((i != theBoss) ? "-" : "b");
                }
                id2.Insert(0, newRow);
            } else
            {
                for (int i = 0; i < 3; i ++)
                {
                    //int room2add = Random.Range(1, GooRooms.Count);
                    int replaceY = Random.RandomRangeInt(0, id2.Count);
                    int replaceX = Random.RandomRangeInt(0, id2[replaceY].Count);
                    while (id2[replaceY][replaceX] == "s" || id2[replaceY][replaceX] == "e" || id2[replaceY][replaceX] == "0" || id2[replaceY][replaceX].Contains("p"))
                    {
                        replaceX = Random.RandomRangeInt(0, id2[replaceY].Count);
                    }
                    int room2replace = Random.Range(1, LavaPuzzleRooms.Count);
                    id2[replaceY][replaceX] = "p" + room2replace.ToString();
                }
                for (int i = 0; i < firstRow.Count; i++)
                {
                    if (i != theBoss)
                    {
                        newRow.Add("-");
                    }
                    else
                    {
                        int[] gemSolution = new int[] { Random.RandomRangeInt(0, 12), Random.RandomRangeInt(0, 12), Random.RandomRangeInt(0, 12) };
                        SavedVars.BossTeleportSolution = gemSolution;
                        newRow.Add("p0");
                    }
                }
                id2.Insert(0, newRow);
                newRow = new List<string>();
                for (int i = 0; i < firstRow.Count; i++)
                {
                    if (i != theBoss)
                    {
                        newRow.Add("-");
                    }
                    else
                    {
                        newRow.Add("b");
                    }
                }
                id2.Insert(0, newRow);
            }

            foreach (List<string> strings in id2)
            {
                string strings2 = "";
                foreach(string stringa in strings)
                {
                    strings2 += stringa;
                    strings2 += ",";
                }
            }

            List<List<List<string>>> RoomT = GooRooms;
            if (room == "espeara")
            {
                RoomT = LavaRooms;
            }
            else if (room == "lonely")
            {
                RoomT = VoidRooms;
            }

            List<string> checkedCells = new List<string>();

            int timesRan = 0;

            for (int y = 0; y < id2.Count; y++)//check for unreachables (new floodfill algorithmface)
            {
                for (int x = 0; x < id2[y].Count; x++)
                {

                    if (checkedCells.Contains(x + ";" + y) || id2[y][x] == "-") { continue; }

                    ids = "\n";

                    for (int y2 = 0; y2 < id2.Count; y2++)//generate id(finally)
                    {
                        for (int x2 = 0; x2 < id2[y2].Count; x2++)
                        {
                            string chart = (id2[y2][x2].Length <= 1) ? id2[y2][x2] : "N";
                            ids += chart + " ";
                        }
                        if (y2 != id2.Count - 1)
                        {
                            ids += "\n";
                        }
                    }

                    timesRan++;

                    bool isIsland = (timesRan > 1);

                    List<string> neighbours = new List<string> { x + ";" + y };

                    for (int i = 0; i < neighbours.Count; i ++)
                    {
                        if (checkedCells.Contains(neighbours[i])) { continue; }

                        string[] cellSplit = neighbours[i].Split(';');
                        int[] cellInt = new int[2] { int.Parse(cellSplit[0]), int.Parse(cellSplit[1]) };

                        List<string> newNeighbours = getAllNodeNeighbours(id2, cellInt[0], cellInt[1], isIsland);


                        checkedCells.Add(neighbours[i]);

                        bool createdBridge = false;

                        for(int j = 0; j < newNeighbours.Count;j++) 
                        {
                            if (checkedCells.Contains(newNeighbours[j]))
                            {
                                newNeighbours.RemoveAt(j);
                                j--;
                                continue;
                            }

                            if (!isIsland || createdBridge) { continue; }

                            string[] cellSplit2 = newNeighbours[j].Split(';');
                            int[] cellInt2 = new int[2] { int.Parse(cellSplit2[0]), int.Parse(cellSplit2[1]) };

                            string bridge = (Random.RandomRangeInt(0, 100) > 45) ? Random.Range(1, RoomT.Count).ToString() : "-";

                            if (id2[cellInt2[1]][cellInt2[0]] == "-" && !createdBridge) { id2[cellInt2[1]][cellInt2[0]] = bridge; createdBridge = true; }
                            else if (id2[cellInt2[1]][cellInt2[0]] == "-")
                            {
                                newNeighbours.RemoveAt(j);
                                j--;
                            }


                            if (createdBridge)
                            {

                                x = 0;
                                y = 0;
                                timesRan = 0;
                            }

                        }

                        neighbours.AddRange(newNeighbours);
                        

                        if (timesRan == 0)
                        {
                            checkedCells = new List<string>();
                            break;

                        }
                    }

                    


                }
            }



            if (room == "goobert" && !SaveManager.saveFile.ascensionActive || room == "espeara" && hasEdaxio || room == "lonely" && hasEdaxio)//add edaxio
            {
                int row = Random.RandomRangeInt(1, id2.Count - 1);
                List<string> edaxioRow = id2[row];
                if (edaxioRow[edaxioRow.Count - 1] == "-")
                {
                    id2[row][edaxioRow.Count - 1] = "e";
                    if (edaxioRow.Count - 2 >= 0 && edaxioRow[edaxioRow.Count - 2] == "-") { id2[row][edaxioRow.Count - 2] = "e"; }
                }
                else
                {
                    id2[row].Add("e");
                }
            }

            ids = "";

            for (int y = 0; y < id2.Count; y++)//generate id(finally)
            {
                for (int x = 0; x < id2[y].Count; x++)
                {
                    ids += id2[y][x] + ",";
                }
                if (y != id2.Count - 1)
                {
                    ids += "/";
                }
            }

            MagnificusMod.MagCurrentNode.SaveLayout(ids);
            return id2;
        }


        public static List<string> getAllNodeNeighbours(List<List<string>> map, int x, int y, bool getAll = false)
        {
            List<string> neighbours = new List<string>();

            if (x > 0 && (getAll || map[y][x - 1] != "-") ) neighbours.Add( (x - 1) + ";" + y);
            if (y < map.Count - 1 && x < map[y + 1].Count && (getAll || map[y + 1][x] != "-")) neighbours.Add(x + ";" + (y + 1));

            if (x < map[y].Count - 1 && (getAll || map[y][x + 1] != "-") ) neighbours.Add( ( x + 1) + ";" + y);
            if (y > 0 && x < map[y - 1].Count && (getAll && y > 1 || map[y - 1][x] != "-") ) neighbours.Add( x + ";" + (y - 1) );

            return neighbours;
        }

        public static List<List<string>> generateMap(List<List<string>> ids, string region)
        {
            List<List<string>> map = new List<List<string>>();
            for (int i = 0; i < ids.Count * 7; i++)//create vertical dimensions
            {
                map.Add(new List<string>());
            }

            List<List<List<string>>> rooms = new List<List<List<string>>>();

            List<List<string>> bossRoom = new List<List<string>>();

            switch (region)//what rooms to use
            {
                case "goobert":
                    rooms = GooRooms;
                    bossRoom = b1;
                    break;
                case "espeara":
                    rooms = LavaRooms;
                    bossRoom = b2;
                    break;
                case "lonely":
                    rooms = VoidRooms;
                    bossRoom = b3;
                    break;
            }

            List<List<int>> blockedByBattle = new List<List<int>>();

            int group = 0;

            int puzzlesMade = 0;

            for (int i = 0; i < ids.Count; i ++)
            {
                for (int x = 0; x < ids[i].Count; x++)
                {
                    List<List<string>> room = new List<List<string>>();//get room
                    if (ids[i][x] == "-")
                    {
                        room = empty;
                    }
                    else if (ids[i][x] == "s")
                    {
                        room = shop[RunState.Run.regionTier - 1];
                    }
                    else if (ids[i][x].Contains("p"))
                    {
                        string[] roomide = ids[i][x].Split('p');
                        int puzzleId = int.Parse(roomide[1]);
                        room = LavaPuzzleRooms[puzzleId];
                        if (region == "lonely")
                        {
                            room = new List<List<string>>();
                            List<List<string>> instance = VoidPuzzleRooms[puzzleId];

                            foreach(List<string> row in instance) room.Add(new List<string>(row));

                            if (puzzleId > 0)
                            {
                                for (int y = 0; y < room.Count; y++)
                                {
                                    for (int xD = 0; xD < room[y].Count; xD++)
                                    {
                                        if (room[y][xD].ToLower().Contains(";")) continue; 

                                        if (room[y][xD].ToLower().Contains("runeh") || room[y][xD].ToLower().Contains("brune")) room[y][xD] += ";" + puzzlesMade;
                                    }
                                }

                                puzzlesMade++;
                            }
                        }
                    }
                    else if (ids[i][x] == "b")
                    {
                        room = bossRoom;
                    } else if (ids[i][x] == "e")
                    {
                        if (region == "goobert")
                        {
                            room = EdaxioRooms[0];
                        } else if (region == "espeara")
                        {
                            room = EdaxioRooms[1];
                        }
                        else if (region == "lonely")
                        {
                            room = EdaxioRooms[2];
                        }
                    }
                    else
                    {
                        if (ids[i][x] != "")
                        {
                            string thinglol = ids[i][x];
                            List<List<string>> roomlol = new List<List<string>>();
                            bool bl = false;
                            if (thinglol.Contains("bl"))
                            {
                                group++;
                                blockedByBattle.Add(new List<int> { i, x, group });
                                string[] tes = thinglol.Split('b');
                                thinglol = tes[0];
                                bl = true;
                            }

                            foreach(List<string> monRovia in rooms[int.Parse(thinglol)])
                            {
                                roomlol.Add(monRovia);
                            }

                            if (bl)//room blocked by battle (Messy!!!)
                            {
                                for (int y = 0; y < roomlol.Count; y++)
                                {
                                    for (int xD = 0; xD < roomlol[y].Count; xD++)
                                    {
                                        if (roomlol[y][xD].ToLower().Contains("d"))
                                        {
                                            string newRoom = "";
                                            for (int el = 0; el <2;el ++)
                                            {
                                                newRoom += roomlol[y][xD][el];
                                            }

                                            newRoom += (roomlol[y][xD].Contains("D")) ? "L" : "l";
                                            newRoom += x +";" + y + ";";
                                            newRoom += group;
                                            roomlol[y][xD] = newRoom;


                                        }
                                    }
                                }
                            }
                            room = roomlol;
                        }
                    }

                    for (int b = 0; b < room.Count; b++)//add room to map
                    {
                        foreach (string block in room[b])
                        {
                            map[i * 7 + b].Add(block);
                        }
                    }
                }
            }

            List<List<int>> doorsToOpen = new List<List<int>>();
            List<List<int>> lockedByBattle = new List<List<int>>();
            List<string> doneThisOne = new List<string>();
            List<int> battleGroups = new List<int>();

            for ( int y = 0; y < map.Count; y++)//create doors (also messy (srry))
            {
                List<string> room = map[y];
                for (int i = 0; i < room.Count; i ++)
                {
                    string block = room[i];
                    if (block.ToLower().Contains("d"))
                    {
                        int bdex = y;
                        int ddex = i;
                        bool connected = false;
                        if (bdex != 0 && bdex != map.Count - 1 && ddex != 0 && ddex != room.Count - 1)//check if the door is valid
                        {
                            if (room[ddex + 1] != " " && room[ddex - 1] != " ")
                            {
                                if (map[bdex + 1].Count > ddex && map[bdex - 1].Count > ddex && map[bdex + 1][ddex] != " " && map[bdex - 1][ddex] != " ") 
                                {
                                    connected = true;
                                }
                            }
                        }

                        if (connected)
                        {
                            doorsToOpen.Add(new List<int> { bdex, ddex });
                        }
                    }
                    else if (block.Contains("L") || block.Contains("l"))
                    {
                        int bdex = y;
                        int ddex = i;
                        bool connected = false;
                        if (bdex != 0 && bdex != map.Count - 1 && ddex != 0 && ddex != room.Count - 1)//check if the door is valid
                        {
                            if (room[ddex + 1] != " " && room[ddex - 1] != " ")
                            {
                                if (map[bdex + 1].Count > ddex && map[bdex - 1].Count > ddex && map[bdex + 1][ddex] != " " && map[bdex - 1][ddex] != " ")
                                {
                                    connected = true;
                                }
                            }
                        }

                        if (connected)
                        {
                            string[] argh;
                            if (block.Contains("L")) {
                                argh = block.Split('L');
                            } else
                            {
                                argh = block.Split('l');
                            }
                            string[] aargh = argh[1].Split(';');
                            int grorp = int.Parse(aargh[2]);
                            int notit = doneThisOne.IndexOf(argh[1]);
                            if (notit < 0)
                            {
                                doneThisOne.Add(argh[1]);
                                lockedByBattle.Add(new List<int> { bdex, ddex });
                                battleGroups.Add(grorp);
                            } else
                            {
                                doorsToOpen.Add(new List<int> { bdex, ddex });
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < doorsToOpen.Count; i ++)
            {
               map[doorsToOpen[i][0]][doorsToOpen[i][1]] = "-";
            }
            for (int i = 0; i < lockedByBattle.Count; i++)
            {
                map[lockedByBattle[i][0]][lockedByBattle[i][1]] = "BL" + battleGroups[i];
            }
            return map;
        }
        
        public static List<List<string>> DecompileLayout(string id)
        {
            string[] ids = id.Split(',');
            List<List<string>> id2 = new List<List<string>> { new List<string>() };
            int y = 0;
            for (int i = 0; i < ids.Length; i ++)
            {
                if (!ids[i].Contains("/") && !ids[i].Contains("}") && !ids[i].Contains("\r"))
                {
                    id2[y].Add(ids[i]);
                } else if (ids[i].Contains("/"))
                {
                    string[] newLayer = ids[i].Split('/');
                    id2.Add(new List<string>());
                    y++;
                    id2[y].Add(newLayer[1]);
                }
            }
            return id2;
        }

    }
}

