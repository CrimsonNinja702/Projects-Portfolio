using Objects_and_classes;

Human human1 = new Human();
Human human2 = new Human();

human1.name = "Flash";
human1.speed = 20000;

human2.name = "Quicksilver";
human2.speed = 1500;

human1.Run();
human2.Stop();

Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

human2.Run();
human1.Stop();

Console.ReadKey();