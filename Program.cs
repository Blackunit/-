using System;
using System.Speech.Recognition;

namespace SpeechConsoleApp3
{
    internal class Program
    {
        static void Main()
        {
            // 创建语音识别引擎
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();

            // 配置语法
            Choices commands = new Choices();
            commands.Add(new string[] { "你好", "我爱你", "I love you"});
            GrammarBuilder grammarBuilder = new GrammarBuilder(commands);
            Grammar grammar = new Grammar(grammarBuilder);

            // 将语法添加到识别引擎
            recognizer.LoadGrammar(grammar);

            // 设置事件处理程序来处理识别结果
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

            // 启动语音识别
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.RecognizeAsync(RecognizeMode.Multiple);

            Console.WriteLine("Listening for commands. Press Enter to exit.");
            Console.ReadLine();

            // 停止识别并释放资源
            recognizer.RecognizeAsyncStop();
            recognizer.Dispose();
        }

        private static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result != null && e.Result.Confidence > 0.6)
            {
                string recognizedText = e.Result.Text;
                Console.WriteLine("Recognized: " + recognizedText);

                // 在此处可以根据 recognizedText 执行相应的操作
                // 例如，执行命令、触发事件等
            }
        }
    }
}
