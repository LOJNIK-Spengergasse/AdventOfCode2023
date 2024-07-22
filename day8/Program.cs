List<bool> instructions = new List<bool>();
List<Crossway> crossways = new List<Crossway>();
try
         {
             using (StreamReader sr = new StreamReader("testdata.txt"))
             {
                 string line;
                 line = sr.ReadLine();
                 for(int i=0; i<line.length; i++){
                    if(line[i]=='R') instructions.Add(true);
                    else instructions.Add(false);
                 }
                 // Filling up Data
                 while ((line = sr.ReadLine()) != null)
                 {
                    string[] splitString = line.Split('=');
                    string name = line[0].Trim();
                    string[] letters = line[1].Trim('(', ')').Split(',');
                    crossways.Add(name, letters[0], letters[1]);
                 }
             }
         }
         catch (Exception e){
             // Let the user know what went wrong.
             Console.WriteLine("The file could not be read:");
             Console.WriteLine(e.Message);
         }