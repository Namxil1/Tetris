using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tetris
{
    internal class ModelXML : IModel
    {
        private IView view;
        private IController controller;
        private XDocument doc;
        IView IModel.View { get => view; set => view=value; }
        IController IModel.Controller { get => controller; set => controller=value; }

        int IModel.getHighscore(int ID)
        {
            //Nur zum Test. Soll aus XML kommen!
            return 69420;
        }

        string IModel.getName(int ID)
        {
            //Nur zum Test. Soll aus XML kommen!
            return "Beast";
        }

        int IModel.GetUserID(string username, string pwd)
        {
            //Nur zum Test. Soll aus XML kommen!
            return 666;
        }

        int IModel.RegisterUser(string username, string pwd)
        {
            throw new NotImplementedException();
        }

        void IModel.setHighscore(int ID, int score)
        {
            throw new NotImplementedException();
        }

        public ModelXML()
        {
            try
            {
                this.doc = XDocument.Load("userlisteoderso.xml");
            }
            catch
            {
                doc = new XDocument(
                    new XElement("userliesteoderso",
                        new XElement("useroderso",
                            new XAttribute("passwort", "12345"),
                            new XElement("name", "Fritz"),
                            new XElement("higscore", "0")
                                    )
                                )
                                              );
                doc.Save("userlisteoderso.xml");
            }
        }

    }
}
