        
        List<bool> instructions = new List<bool>();
        List<Crossway> crossways = new List<Crossway>();

        try
        {
            using (StreamReader sr = new StreamReader("data.txt"))
            {
                string line;
                line = sr.ReadLine();
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == 'R') instructions.Add(true); //true = right
                    else instructions.Add(false); //false = left
                }
                // Filling up Data
                sr.ReadLine(); //skip empty line
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitString = line.Split('=');
                    string name = splitString[0].Trim();
                    string[] letters = splitString[1].Trim(' ', '(', ')').Split(',');
                    letters[1]=letters[1].Trim(' ');
                    crossways.Add(new Crossway(name, letters[0], letters[1]));
                }
            }

            foreach (Crossway c in crossways)
            {
                int index = crossways.FindIndex(cw => cw.Name == c.Name);
                c.NavLeftway = crossways[crossways.FindIndex(cw => cw.Name == c.Leftway)];
                c.NavRightway = crossways[crossways.FindIndex(cw => cw.Name == c.Rightway)];
                //Console.WriteLine($"{c.Name}, {c.NavLeftway?.Name}, {c.NavRightway?.Name}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(e.Message);
        }

        ulong steps=0;
        List<Crossway> currentCrossways=new List<Crossway>();
        foreach(Crossway c in crossways){
            if(c.Name[2]=='A') currentCrossways.Add(new Crossway(c));
        }
        int checkSum=0;
        while (currentCrossways.Count()!=checkSum){
            foreach(bool b in instructions){
                checkSum=0;
                foreach(Crossway c in currentCrossways){
                    //Console.WriteLine($"current: {c.Name}, direction: {b}, current step: {steps}, checkSum: {checkSum}");
                    if(b){
                        c.Clone(c.NavRightway);
                    }
                    else{
                        c.Clone(c.NavLeftway);
                    }
                    if(c.Name[2]=='Z') checkSum++;
                    if(checkSum>=4) Console.WriteLine($"new: {c.Name}, checkSum: {checkSum}, step: {steps}");
                }
                steps++;
            }
            //if(steps>10) checkSum=currentCrossways.Count(); //failsave
        }
        Console.WriteLine($"steps: {steps}");