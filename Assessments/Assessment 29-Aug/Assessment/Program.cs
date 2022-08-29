using Beds;
using Doctors;
using Patients;
using System;
using System.Collections.Generic;

namespace Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            string repeat = "Y";        // For repeating the process as per the user's choice
            int n;

            // Creating lists to store their respective data in the lists
            List<DoctorsCls> docList = new List<DoctorsCls> { };
            List<PatientsCls> patList = new List<PatientsCls> { };
            List<BedsCls> bedList = new List<BedsCls> { };

            while(repeat.ToUpper() == "Y")
            {
                Console.WriteLine("Enter 1 for Doctor Registration, 2 for Patient Registration & 3 for Booking a Bed for Patient");
                n = int.Parse(Console.ReadLine());

                switch(n)
                {
                    case 1:
                        DoctorsCls newDoc = new DoctorsCls();        // Doctors object creation for doctor registration

                        Console.WriteLine("\nPlease enter doctor's ID, Name, Specialization, Age, Email, Mobile, Salary & Address");
                        newDoc.id = int.Parse(Console.ReadLine());
                        newDoc.name = Console.ReadLine();
                        newDoc.specialization = Console.ReadLine();
                        newDoc.age = int.Parse(Console.ReadLine());
                        newDoc.email = Console.ReadLine();
                        newDoc.mobile = Console.ReadLine();
                        newDoc.getSalary = int.Parse(Console.ReadLine());
                        newDoc.getAddress = Console.ReadLine();

                        // Adding the new object to the list
                        docList.Add(newDoc);

                        // Printing all the objects in the list, including the latest addition
                        foreach (DoctorsCls doc in docList)
                        {
                            Console.WriteLine("\n" + doc.id + " / " + doc.name 
                                + " / " + doc.specialization + " / " + 
                                doc.age + " / " + doc.email + " / " + 
                                doc.mobile + " / " + doc.getSalary + 
                                " / " + doc.getAddress);
                        }

                        break;

                    case 2:
                        PatientsCls newPat = new PatientsCls();        // Patients object creation for patient registration

                        Console.WriteLine("\nPlease enter patient's ID, Name, Age, Email, Mobile, Insurance ID, Address & if the patient is vaccinated or not");
                        newPat.id = int.Parse(Console.ReadLine());
                        newPat.name = Console.ReadLine();
                        newPat.age = int.Parse(Console.ReadLine());
                        newPat.email = Console.ReadLine();
                        newPat.mobile = Console.ReadLine();
                        newPat.getInsID = int.Parse(Console.ReadLine());
                        newPat.getAddress = Console.ReadLine();
                        newPat.vaccRec = Console.ReadLine();

                        // Adding the new object to the list
                        patList.Add(newPat);

                        // Printing all the objects in the list, including the latest addition
                        foreach (PatientsCls pat in patList)
                        {
                            Console.WriteLine("\n" + pat.id + " / " + pat.name
                                + " / " + pat.age + " / " + pat.email + " / " + 
                                pat.mobile + " / " +pat.getInsID + " / " + 
                                pat.getAddress + " / " + pat.vaccRec);
                        }

                        break;

                    case 3:
                        BedsCls bedObj = new BedsCls();        // Beds object creation for beds booking for patients

                        Console.WriteLine("\nEnter the Room Number, Bed Number & ID of the patient who will be occupying the bed:");
                        bedObj.roomNo = int.Parse(Console.ReadLine());
                        bedObj.bedNo = int.Parse(Console.ReadLine());
                        bedObj.patID = int.Parse(Console.ReadLine());

                        // Adding the new object to the list
                        bedList.Add(bedObj);

                        // Printing all the objects in the list, including the latest addition
                        foreach (BedsCls bed in bedList)
                        {
                            Console.WriteLine("\n" + bed.roomNo + " / " + bed.bedNo + " / " + bed.patID);
                        }

                        break;

                    default:
                        Console.WriteLine("*****INCORRECT CHOICE!*****");

                        break;
                }

                 // Prompt for repeation of the whole process

                Console.WriteLine("\nDo you want to continue? (Y/N)");
                repeat = Console.ReadLine();
            }
        }
    }
}
