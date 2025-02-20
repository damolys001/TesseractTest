//namespace TesseractTest
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello, World!");
//        }
//    }
//}

using System;
using Tesseract;

namespace TesseractTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                string currentDirectory = Environment.CurrentDirectory;
                Console.WriteLine($"Current Directory (Environment.CurrentDirectory): {currentDirectory}");



                // Specify the tessdata path (update this path if Tesseract is installed in a different directory)
                string tessDataPath = @"Tesseract-OCR\tessdata";
                //string tessDataPath = @"C:\Program Files\Tesseract-OCR\tessdata";
                //string tessDataPath = "/usr/share/tesseract-ocr/4.00/tessdata/";

                // Initialize the Tesseract engine
                using (var engine = new TesseractEngine(tessDataPath, "eng", EngineMode.Default))
                {
                    // Load the test image (update the path to your test image)
                    string imagePath = @"Tesseract-OCR\tessdata\test_image.jpg";
                   // string imagePath = @"C:\Program Files\Tesseract-OCR\tessdata\test_image.jpg";
                    using (var img = Pix.LoadFromFile(imagePath))
                    {
                        // Perform OCR
                        using (var page = engine.Process(img))
                        {
                            string text = page.GetText();
                            Console.WriteLine("Extracted Text:");
                            Console.WriteLine(text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

