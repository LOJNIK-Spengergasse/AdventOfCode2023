        /*
        List<bool> instructions = new List<bool>();
        List<CrosswayAdvent> crossways = new List<CrosswayAdvent>();

        try
        {
            using (StreamReader sr = new StreamReader("testdata.txt"))
            {
                string line;
                line = sr.ReadLine();
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == 'R') instructions.Add(true);
                    else instructions.Add(false);
                }

                // Filling up Data
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitString = line.Split('=');
                    string name = splitString[0].Trim();
                    string[] letters = splitString[1].Trim('(', ')').Split(',');
                    crossways.Add(new CrosswayAdvent(name, letters[0], letters[1]));
                }
            }

            foreach (CrosswayAdvent c in crossways)
            {
                int index = crossways.FindIndex(cw => cw.Name == c.Name);
                c.NavLeftway = crossways[crossways.FindIndex(cw => cw.Name == c.Leftway)];
                c.NavRightway = crossways[crossways.FindIndex(cw => cw.Name == c.Rightway)];

                Console.WriteLine($"{c.Name}, {c.NavLeftway?.Name}, {c.NavRightway?.Name}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(e.Message);
        }*/