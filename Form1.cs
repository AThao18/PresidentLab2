using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2President
{
    public partial class Form1 : Form
    {
        string outPut = " ";
        string outPut2 = " ";
        

        private object abc;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Main Body

            //Fill in comboBox1 President's names
            comboBox1.Items.AddRange(new object[]
            {
                    "George Washington",
                    "John Adams",
                    "Thomas Jefferson",
                    "James Madison",
                    "James Monroe",
                    "John Quincy Adams",
                    "Andrew Jackson",
                    "Martin Van Buren",
                    "William Henry Harrison",
                    "John Tyler",
                    "James Polk",
                    "Zachary Taylor",
                    "Millard Fillmore",
                    "Franklin Pierce",
                    "James Buchanan",
                    "Abraham Lincoln",
                    "Andrew Johnson",
                    "Ulysses Grant",
                    "Rutherford Hayes",
                    "James Garfield",
                    "Chest Arthur",
                    "Stephen Grover Cleveland",
                    "William Mckinley",
                    "Theodore Roosevelt",
                    "William Taft",
                    "Woodrow Wilson",
                    "Warren Harding",
                    "Calvin Coolidge",
                    "Herbert Hoover",
                    "Franklin Roosevelt",
                    "Harry Truman",
                    "Dwight Eisenhower",
                    "John Kennedy",
                    "Lyndon Johnson",
                    "Richard Nixon",
                    "Gerald Ford",
                    "James Carter",
                    "Ronald Reagan",
                    "George Bush",
                    "William Clinton",
                    "George W Bush",
                    "Barack Obama",
                    "Donald Trump"
            });//comboBox1

            //1st listBox
            listBox1.Items.AddRange(new object[]
            {

                    "First Spouse",
                    "First VP",
                    "First Opponent",
                    "Religion",
                    "Date Born",
                    "Date Death"
            });//Populate categoires into the 1st listBox

            //2nd comboBox
            comboBox2.Items.AddRange(new object[]
                {
                    "Party",
                    "Occupation",
                    "Cause of Death",
                    "Education"
            });//Adding all category in 2nd comboBox

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Party")//Party
            {
                listBox2.Items.Clear(); //Clears the items in the list box

                listBox2.Items.AddRange(new object[]
                    {
                        "None",
                        "Federalist",
                        "Dem-Rep",
                        "Democratic",
                        "Republican",
                        "Union"
                    });
            }
            else if (comboBox2.SelectedItem.ToString() == "Occupation")//Occupation
                {
                    listBox2.Items.Clear();

                    listBox2.Items.AddRange(new object[]
                    {
                        "Planter/Farmer",
                        "Lawyer",
                        "Soldier",
                        "Tailor",
                        "Teacher",
                        "Businessman",
                        "Other"
                    });
                }
            else if (comboBox2.SelectedItem.ToString() == "Cause of Death")//Cause of Death Why did this disappear?
            {
                listBox2.Items.Clear();

                listBox2.Items.AddRange(new object[]
                {
                        "Stroke",
                        "Cancer",
                        "Heart Attack",
                        "Alzheimer",
                        "Gun Shot",
                        "Other"
                });
            }
            else if (comboBox2.SelectedItem.ToString() == "Education")//Education 
                {
                    listBox2.Items.Clear();

                    listBox2.Items.AddRange(new object[]
                    {
                        "None",
                        "Harvard",
                        "Oxford",
                        "Yale",
                        "Duke",
                        "Other"
                    });
                }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            const int Properties = 38; //There are 38 columns in the csv file
            string filePath = "C:\\Users\\thaaar\\Presidents.csv";
            string strRead;
            string abc = ",";

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader readerClass = new StreamReader(fs);

            int count = 0;
            count = GetCount(filePath); //return number of lines including header

            //create a President object array by one instance per row
            President[] presidents = new President[count];
            for (int i = 0; i < count; i++)
            {
                presidents[i] = new President();
            }

            //retrieving the records
            string[] records = new string[Properties];
            for (int counter = 1; counter < count; ++counter)
            {
                strRead = readerClass.ReadLine();

                records = strRead.Split(',');

                presidents[counter].FirstName = records[1];
                presidents[counter].LastName = records[2];
                presidents[counter].FirstSpouse = records[15];
                presidents[counter].FirstVP = records[4];
                presidents[counter].FirstOpponent = records[22];
                presidents[counter].Religion = records[18];
                presidents[counter].DateDeath = records[13];
                presidents[counter].DateBorn = records[12];
            }
            readerClass.Close();
            fs.Close();

            int x = comboBox1.SelectedIndex + 4;
            string outputString = $"{presidents[x].FirstName} {presidents[x].LastName}";

            int listInfoSelected = listBox1.SelectedItems.Count;
            string[] infoOptions = new string[listInfoSelected];
            int infoOptionsCount = 0;

            foreach (var infoOption in listBox1.SelectedItems)
            {
                infoOptions[infoOptionsCount] = infoOption.ToString();
                infoOptionsCount++;
            }

            string writeString = "";

            for (int y = 0; y < infoOptions.Length; y++)
            {
                if(infoOptions[y] == "First Spouse") //First Spouse
                {
                    outputString += $"\n First Spouse: {presidents[x].FirstSpouse}";
                    writeString += $"{presidents[x].FirstSpouse} {abc}";
                }
                else if (infoOptions[y] == "First VP") //First VP
                {
                    outputString += $"\n First VP: {presidents[x].FirstVP}";
                    writeString += $"{presidents[x].FirstVP} {abc}";
                }
                else if (infoOptions[y] == "First Opponent")
                {
                    outputString += $"\n First Opponent: {presidents[x].FirstOpponent}";
                    writeString += $"{presidents[x].FirstOpponent} {abc}";
                }
                else if (infoOptions[y] == "Religion") //Relgion
                {
                    outputString += $"\n Religion: {presidents[x].Religion}";
                    writeString += $"{presidents[x].Religion} {abc}";
                }
                else if (infoOptions[y] == "Date Born") //Date Born
                {
                    outputString += $"\n Date Born: {presidents[x].DateBorn}";
                    writeString += $"{presidents[x].Religion} {abc}";
                }
                else if (infoOptions[y] == "Date Death") //Date Death
                {
                    outputString += $"\n Date Death: {presidents[x].DateDeath}";
                    writeString += $"{presidents[x].DateDeath} {abc}";
                }
            }

            MessageBox.Show(outputString);
        }//end of button1 




        static int GetCount(string file)
        {
            int count = 0;
            string strRead;
            FileStream sr = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader readerCount = new StreamReader(sr);

            strRead = readerCount.ReadLine(); 

            while (strRead != null)
            {
                ++count;
                strRead = readerCount.ReadLine();
            }

            return count;
        }//end GetCount method





        private void button2_Click(object sender, EventArgs e)
        {
            const int Properties = 38; //There are 38 columns in the csv file
            string filePath = "C:\\Users\\thaaar\\Presidents.csv";
            string strRead;
            string abc = ",";

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader readerClass = new StreamReader(fs);

            int count = 0;
            count = GetCount(filePath); //return number of lines including header

            //create a President object array by one instance per row
            President[] presidents = new President[count];
            for (int i = 0; i < count; i++)
            {
                presidents[i] = new President();
            }

            //retrieving the records
            string[] records = new string[Properties];
            for (int counter = 1; counter < count; ++counter)
            {
                strRead = readerClass.ReadLine();

                records = strRead.Split(',');

                presidents[counter].FirstName = records[1];
                presidents[counter].LastName = records[2];
                presidents[counter].FirstSpouse = records[15];
                presidents[counter].FirstVP = records[4];
                presidents[counter].FirstOpponent = records[22];
                presidents[counter].Religion = records[18];
                presidents[counter].DateDeath = records[13];
                presidents[counter].DateBorn = records[12];
            }
            readerClass.Close();
            fs.Close();

            int x = comboBox1.SelectedIndex + 2;
            string outputString = $"{presidents[x].FirstName} {presidents[x].LastName}";

            int listInfoSelected = listBox1.SelectedItems.Count;
            string[] infoOptions = new string[listInfoSelected];
            int infoOptionsCount = 0;

            foreach (var infoOption in listBox1.SelectedItems)
            {
                infoOptions[infoOptionsCount] = infoOption.ToString();
                infoOptionsCount++;
            }

            string writeString = "";

            for (int y = 0; y < infoOptions.Length; y++)
            {
                if (infoOptions[y] == "First Spouse") //First Spouse
                {
                    outputString += $"\n First Spouse: {presidents[x].FirstSpouse}";
                    writeString += $"{presidents[x].FirstSpouse} {abc}";
                }
                else if (infoOptions[y] == "First VP") //First VP
                {
                    outputString += $"\n First VP: {presidents[x].FirstVP}";
                    writeString += $"{presidents[x].FirstVP} {abc}";
                }
                else if (infoOptions[y] == "First Opponent")
                {
                    outputString += $"\n First Opponent: {presidents[x].FirstOpponent}";
                    writeString += $"{presidents[x].FirstOpponent} {abc}";
                }
                else if (infoOptions[y] == "Religion") //Relgion
                {
                    outputString += $"\n Religion: {presidents[x].Religion}";
                    writeString += $"{presidents[x].Religion} {abc}";
                }
                else if (infoOptions[y] == "Date Born") //Date Born
                {
                    outputString += $"\n Date Born: {presidents[x].DateBorn}";
                    writeString += $"{presidents[x].Religion} {abc}";
                }
                else if (infoOptions[y] == "Date Death") //Date Death
                {
                    outputString += $"\n Date Death: {presidents[x].DateDeath}";
                    writeString += $"{presidents[x].DateDeath} {abc}";
                }
            }

            string fileWritePath = "C:\\Users\\thaaar\\Presidents-info.csv";
            FileStream outFile2 = new FileStream(fileWritePath, FileMode.Append, FileAccess.Write);
            StreamWriter writerCSV = new StreamWriter(outFile2);

            writerCSV.WriteLine(writeString);

            writerCSV.Close();
            outFile2.Close();

            outputString += "\n selected info written to C:\\Users\\thaaar\\Presidents.csv";
            MessageBox.Show(outputString);
        }//end of button2 write class




        //Begining the seconde options. You should be able to use the same set of codes above
        //for most of the the second one.
        private void button3_Click(object sender, EventArgs e)
        {
            //get button2 for values
            const int Properties = 38; //There are 38 columns in the csv file
            string filePath = "C:\\Users\\thaaar\\Presidents.csv";
            string strRead;
            outPut = " ";

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader readerClass = new StreamReader(fs);

            int count = 0;
            count = GetCount(filePath); //return number of lines including header

            //creating an array for President
            President[] presidents = new President[count];
            for (int i=0; i < count; ++i)
            {
                presidents[i] = new President();
            }

            //getting informations from csv
            string[] information = new string[Properties];
            for (int counter = 1; counter < count; ++counter)
            {
                strRead = readerClass.ReadLine();

                information = strRead.Split(',');

                presidents[counter].FirstName = information[1];
                presidents[counter].LastName = information[2];
                presidents[counter].Party = information[3];
                presidents[counter].Occupation = information[20];
                presidents[counter].CauseofDeath = information[34];
                presidents[counter].Education = information[19];
            }
            readerClass.Close();
            fs.Close();

            int listBox2Selected = listBox2.SelectedItems.Count;
            string[] value = new string[listBox2Selected];
            int listBox2Count = 0;

            foreach (var values in listBox2.SelectedItems )
            {
                value[listBox2Count] = values.ToString();
                listBox2Count++;
            }



            for (int x = 0; x < value.Length; x++)
            {
                //party
               
                    if (value[x] == "None")
                    {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Party.Trim() == "no designation")//when i change this to no designation, the output list education instead
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Party}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Party} {abc}\r\n";
                        }
                    }
                    }
                else if (value[x] == "Federalist")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Party.Trim() == "Federalist")
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Party}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Party} {abc}\r\n";
                        }
                    }
                }//Federalist
                else if (value[x] == "Dem-Rep")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Party.Trim() == "Dem-Rep")
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Party}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Party} {abc}\r\n";
                        }
                    }
                }//Dem-Rep
                else if (value[x] == "Democratic")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Party.Trim() == "Democratic")
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Party}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Party} {abc}\r\n";
                        }
                    }
                }//Democratic
                else if (value[x] == "Republican")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Party.Trim() == "Republican")
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Party}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Party} {abc}\r\n";
                        }
                    }
                }//Republican
                else if (value[x].Trim() == "Union")//.Trim is optional
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Party.Trim() == "Union")//This line of code saperates the party from the others
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Party}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Party} {abc}\r\n";
                        }
                    }
                }//Union

                    //Occupation

                else if (value[x] == "Planter/Farmer")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        
                        if (presidents[y].Occupation.Trim() == "Farmer" || presidents[y].Occupation.Trim() == "Planter")//Nothing appears 
                        {
                            
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Occupation}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Occupation} {abc}\r\n";
                        }
                    }
                }//Farmer

                else if (value[x] == "Lawyer")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Occupation.Trim() == "Lawyer")
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Occupation}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Occupation} {abc}\r\n";
                        }
                    }
                }//Lawyer

                else if (value[x] == "Soldier")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Occupation.Trim() == "Soldier")//Error
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Occupation}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Occupation} {abc}\r\n";
                        }
                    }
                }//soldier

                else if (value[x] == "Tailor")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Occupation.Trim() == "Tailor")//works
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Occupation}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Occupation} {abc}\r\n";
                        }
                    }
                }//Tailor
                else if (value[x] == "Teacher")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Occupation.Trim() == "Teacher")//works
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Occupation}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Occupation} {abc}\r\n";
                        }
                    }
                }//Teacher

                else if (value[x] == "Businessman")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Occupation.Trim() == "Businessman")//works
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Occupation}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Occupation} {abc}\r\n";
                        }
                    }
                }//Businessman


                else if (value[x] == "Other")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Occupation.Trim() != "Businessman" && presidents[y].Occupation.Trim() != "Teacher" && 
                            presidents[y].Occupation.Trim() != "Soldier" && presidents[y].Occupation.Trim() != "Tailor" && 
                            presidents[y].Occupation.Trim() != "Lawyer" && presidents[y].Occupation.Trim() != "Farmer"  && 
                            presidents[y].Occupation.Trim() != "Planter")
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Occupation}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Occupation} {abc}\r\n";
                        }
                    }
                }//Other

                //Cause of death
                else if (value[x] == "Stroke")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        
                        if (presidents[y].CauseofDeath.Trim() == "stroke")
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].CauseofDeath}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].CauseofDeath} {abc}\r\n";
                        }
                    }
                }//Stroke
                else if (value[x] == "Cancer")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].CauseofDeath.Trim() == "throat cancer")
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].CauseofDeath}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].CauseofDeath} {abc}\r\n";
                        }
                    }
                }//Cancer
                else if (value[x] == "Heart Attack")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].CauseofDeath.Trim() == "heart failure" && presidents[y].CauseofDeath.Trim() == "heart disease" &&
                            presidents[y].CauseofDeath.Trim() == "heart attack")//!!!
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].CauseofDeath}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].CauseofDeath} {abc}\r\n";
                        }
                    }
                }//Heart Attack
                else if (value[x] == "Alzheimer")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].CauseofDeath.Trim() == "Alzheimer's disease")
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].CauseofDeath}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].CauseofDeath} {abc}\r\n";
                        }
                    }
                }//Alzheimer
                else if (value[x] == "Gunshot")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].CauseofDeath.Trim() == "gunshot wound")//!!!
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].CauseofDeath}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].CauseofDeath} {abc}\r\n";
                        }
                    }
                }//Gunshot
                else if (value[x] == "other")//this will list occupation 
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].CauseofDeath.Trim() != "heart failure" && presidents[y].CauseofDeath.Trim() != "heart dsiease" &&
                            presidents[y].CauseofDeath.Trim() != "stroke" && presidents[y].CauseofDeath.Trim() != "Alzheimer's disease" &&
                            presidents[y].CauseofDeath.Trim() != "gunshot wound")
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].CauseofDeath}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].CauseofDeath} {abc}\r\n";
                        }
                    }
                }//Other
                else if (value[x] == "None")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Education}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Education} {abc}\r\n";
                    }
                }//None
                else if (value[x] == "Harvard")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Education.Trim() == "Harvard" && presidents[y].Education.Trim() == "Harvard College" &&
                            presidents[y].Education.Trim() != "Harvard Law School")
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Education}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Education} {abc}\r\n";
                        }
                    }
                }//Harvard
                else if (value[x] == "Oxford")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Education.Trim() == "Oxford")
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Education}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Education} {abc}\r\n";
                    }
                }//Oxford
                else if (value[x] == "Yale")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Education.Trim() == "Yale")
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Education}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Education} {abc}\r\n";
                        }
                    }
                }//Yale
                else if (value[x] == "Duke")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Education.Trim() == "Duke University Law School")
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Education}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Education} {abc}\r\n";
                        }
                    }
                }//Duke
                else if (value[x] == "Other")//Error
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Education.Trim() != "no formal" && presidents[y].Education.Trim() != "Harvard" &&
                            presidents[y].Education.Trim() != "Harvard College" && presidents[y].Education.Trim() != "No formal education" &&
                            presidents[y].Education.Trim() != "Oxford" && presidents[y].Education.Trim() != "Harvard" &&
                            presidents[y].Education.Trim() != "Duke Unicersity Law School" && presidents[y].Education.Trim() != "Yale")
                            
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Education}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Education} {abc}\r\n";
                        }
                    }
                }//Other

                
                MessageBox.Show(outPut);
            }

        }//end of get button 3  get




        private void button4_Click(object sender, EventArgs e)
        {
            //button 4 write
            const int Properties = 38; //There are 38 columns in the csv file
            string filePath = "C:\\Users\\thaaar\\Presidents.csv";
            string strRead;

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader readerClass = new StreamReader(fs);

            int count = 0;
            count = GetCount(filePath); //return number of lines including header

            //creating an array for President
            President[] presidents = new President[count];
            for (int i = 0; i < count; ++i)
            {
                presidents[i] = new President();
            }

            //getting informations from csv
            string[] information = new string[Properties];
            for (int counter = 1; counter < count; ++counter)
            {
                strRead = readerClass.ReadLine();

                information = strRead.Split(',');

                presidents[counter].FirstName = information[1];
                presidents[counter].LastName = information[2];
                presidents[counter].Party = information[3];
                presidents[counter].Occupation = information[10];
                presidents[counter].CauseofDeath = information[34];
                presidents[counter].Education = information[19];
            }
            readerClass.Close();
            fs.Close();

            int listBox2Selected = listBox2.SelectedItems.Count;
            string[] value = new string[listBox2Selected];
            int listBox2Count = 0;

            foreach (var values in listBox2.SelectedItems)
            {
                value[listBox2Count] = values.ToString();
                listBox2Count++;
            }

            string outPut = " ";
            string outPut2 = " ";

            for (int x = 0; x < value.Length; x++)
            {


                if (value[x] == "None")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Party}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Party} {abc}\r\n";
                    }
                }
                else if (value[x] == "Federalist")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        if (presidents[y].Party.Trim() == "Federalist")
                        {
                            outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Party}\r\n";
                            outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Party} {abc}\r\n";
                        }
                    }
                }//Federalist
                else if (value[x] == "Dem-Rep")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Party}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Party} {abc}\r\n";
                    }
                }//Dem-Rep
                else if (value[x] == "Democratic")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Party}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Party} {abc}\r\n";
                    }
                }//Democratic
                else if (value[x] == "Republican")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Party}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Party} {abc}\r\n";
                    }
                }//Republican
                else if (value[x] == "Union")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Party}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Party} {abc}\r\n";
                    }
                }//Union
                else if (value[x] == "Farmer")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Occupation}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Occupation} {abc}\r\n";
                    }
                }//Farmer
                else if (value[x] == "Lawyer")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Occupation}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Occupation} {abc}\r\n";
                    }
                }//Lawyer
                else if (value[x] == "Soldier")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Occupation}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Occupation} {abc}\r\n";
                    }
                }//soldier
                else if (value[x] == "Tailor")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Occupation}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Occupation} {abc}\r\n";
                    }
                }//Tailor
                else if (value[x] == "Teacher")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Occupation}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Occupation} {abc}\r\n";
                    }
                }//Teacher
                else if (value[x] == "Businessman")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Occupation}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Occupation} {abc}\r\n";
                    }
                }//Businessman
                else if (value[x] == "Other")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Occupation}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Occupation} {abc}\r\n";
                    }
                }//Other
                else if (value[x] == "Stroke")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].CauseofDeath}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].CauseofDeath} {abc}\r\n";
                    }
                }//Stroke
                else if (value[x] == "Cancer")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].CauseofDeath}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].CauseofDeath} {abc}\r\n";
                    }
                }//Cancer
                else if (value[x] == "Heart Attack")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].CauseofDeath}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].CauseofDeath} {abc}\r\n";
                    }
                }//Heart Attack
                else if (value[x] == "Alzheimer")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].CauseofDeath}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].CauseofDeath} {abc}\r\n";
                    }
                }//Alzheimer
                else if (value[x] == "Gunshot")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].CauseofDeath}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].CauseofDeath} {abc}\r\n";
                    }
                }//Gunshot
                else if (value[x] == "Other")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].CauseofDeath}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].CauseofDeath} {abc}\r\n";
                    }
                }//Other
                else if (value[x] == "None")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Education}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Education} {abc}\r\n";
                    }
                }//None
                else if (value[x] == "Harvard")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Education}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Education} {abc}\r\n";
                    }
                }//Harvard
                else if (value[x] == "Oxford")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Education}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Education} {abc}\r\n";
                    }
                }//Oxford
                else if (value[x] == "Yale")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Education}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Education} {abc}\r\n";
                    }
                }//Yale
                else if (value[x] == "Duke")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Education}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Education} {abc}\r\n";
                    }
                }//Duke
                else if (value[x] == "Other")
                {
                    for (int y = 2; y < presidents.Length; y++)
                    {
                        outPut += $"{presidents[y].FirstName} {presidents[y].LastName} {presidents[y].Education}\r\n";
                        outPut2 += $"{presidents[y].FirstName} {abc} {presidents[y].LastName} {abc} {presidents[y].Education} {abc}\r\n";
                    }
                }//Other

                string fileWritePath = "C:\\Users\\thaaar\\Presidents-info.csv";
                FileStream outFile2 = new FileStream(fileWritePath, FileMode.Append, FileAccess.Write);
                StreamWriter writerCSV = new StreamWriter(outFile2);

                writerCSV.WriteLine(outPut2);

                writerCSV.Close();
                outFile2.Close();

                outPut += "\n selected info written to C:\\Users\\thaaar\\Presidents.csv";
                MessageBox.Show(outPut);
            }




        }//end of button 4 write
    }
    public class President
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirstSpouse { get; set; }
        public string FirstVP { get; set; }
        public string FirstOpponent { get; set; }
        public string Religion { get; set; }
        public string DateDeath { get; set; }
        public string DateBorn { get; set; }
        public string Party { get; set; }
        public string Occupation { get; set; }
        public string CauseofDeath { get; set; }
        public string Education { get; set; }

      
        
    }
}
