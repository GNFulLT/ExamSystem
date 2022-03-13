using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamSystem
{
    static public class Globals
    {
        static public AppSettings MySettings = new AppSettings();
        static public DatabaseHandler database = new DatabaseHandler();
        static public EmailHandler EmailHandle = new EmailHandler();
    }
}
