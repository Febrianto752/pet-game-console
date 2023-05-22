using System;

namespace App
{
    class Program
    {
        static void printTitle()
        {
            Console.WriteLine("==== Pet Game ====\n");
        }
        static void Main(string[] args) {
            // deklarasi variabel" yang dibutuhkan
            string  petType = null, pilihPet = null, pilihMenu = null, lanjut = null;
            Animal pet = default;           
            
            while(petType == null)
            {
                printTitle();
                Console.WriteLine("Selamat Datang di Pet Game \n");
                Console.WriteLine("Silakan pilih jenis peliharaan anda : ");
                Console.WriteLine("1. Kucing");
                Console.WriteLine("2. Anjing");
                Console.Write("\npilihan anda [1 atau 2] : ");

                // user memilih jenis peliharaan kucing atau anjing
                pilihPet = Console.ReadLine();

                if (pilihPet == "1")
                {
                    petType = "Kucing";
                    pet = new Cat();
                }
                else if (pilihPet == "2")
                {
                    petType = "Anjing";
                    pet = new Dog();
                    
                }
                else
                {
                    Console.WriteLine("\nAnda memasukan nilai yang salah!, silakan pilih pilihan yang tersedia");
                    Thread.Sleep(2000);
                    
                }
                Console.Clear();
            }

            while(pilihMenu != "4")
            {
                printTitle();
                Console.WriteLine("Jenis Peliharaan : {0}", petType);
                Console.WriteLine("Energi {0} anda : {1}\n", petType.ToLower(), pet.Energy);

                Console.WriteLine("======= Menu Utama ========");
                Console.WriteLine("1. Beri makan");
                Console.WriteLine("2. Suara Peliharaan");
                Console.WriteLine("3. Bermain");
                Console.WriteLine("4. Selesai");
                Console.WriteLine("===========================");
                Console.Write("Pilihan [1-4] : ");
                pilihMenu = Console.ReadLine();

                Console.Clear();
                printTitle();

                // penentuan hasil output yang keluar berdasarkan pilihan user
                switch (pilihMenu)
                {
                    case "1":
                        Console.WriteLine("{0} : {1}", petType, pet.animalEat());
                        break;
                    case "2":
                        Console.WriteLine("{0} : {1}", petType, pet.animalSound());
                        break;
                    case "3":
                        Console.WriteLine("{0} : {1}", petType, pet.animalPlay());
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak tersedia, silakan pilih pilihan yang tersedia!");
                        break;
                }

                // program selesai
                if (pilihMenu == "4") {
                    break;
                }

                Console.Write("\nIngin kembali ke menu utama ? (y/n) : ");
                // jika ingin bermain lagi
                lanjut = Console.ReadLine();

                if (lanjut == "y" || lanjut == "Y")
                {
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Program Selesai");
        }
    }

    abstract class Animal {
        protected int energy = 100;
        public int Energy { get { return energy; } set { energy = value; } }
        public abstract string animalSound();
        public abstract string animalEat();
        public abstract string animalPlay();  
    }

    class Cat : Animal
    {       
        public override string animalSound()
        {
            if (energy < 30)
            {
                return "aku lapar..., aku tidak mau bersuara!";
            }

            energy -= 10;
            return "\"meong...\"";
        }

        public override string animalEat()
        {
            energy = 100;
            return "\"nyam\" enak..., energiku kembali pulih, meong...\"";
        }

        public override string animalPlay()
        {
            if (energy < 30)
            {
                return "aku lapar..., aku tidak bisa diajak bermain!";
            }

            energy -= 20;
            return "\"asiknya bermain dengan majikanku, meong...\"";
        }
    }

    class Dog : Animal
    {
        public override string animalSound()
        {
            if (energy < 30)
            {
                return "aku lapar..., aku tidak mau bersuara!";
            }
            energy -= 10;
            return "\"gukguk...\"";
        }

        public override string animalEat()
        {
            energy = 100;
            return "\"nyam\" enak..., energiku kembali pulih, guk...\"";
        }

        public override string animalPlay()
        {
            if (energy < 30)
            {
                return "aku lapar..., aku tidak bisa diajak bermain!";
            }

            energy -= 20;
            return "\"asiknya bermain dengan majikanku, guk...\"";
        }
    }
}















// Spec : 
// initial energy = 100

// bersuara->output : string dan energy - 5
//	- kucing : meong...
//	- anjing : gukguk...

// ajak bermain -> output : string dan energy - 20
//	// energy > 30
//	- kucing dan anjing : "asiknya bermain dengan majikanku"

//    // energy < 30
//    - kucing dan anjing : "aku lapar..., aku tidak bisa diajak bermain!"


//beri makan -> output : string dan energy = 100
//	-> kucing dan anjing : nyam" enak..., energiku kembali pulih