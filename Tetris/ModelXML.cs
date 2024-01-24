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
        IView IModel.View { get => view; set => view=value; }
        IController IModel.Controller { get => controller; set => controller=value; }

        int IModel.getHighscore(int ID)
        {
            //Nur zum Test. Soll aus XML kommen!
            return 4711;
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
            //Nur zum Test. Muss an die Aufgabe angepasst werden.
            XDocument doc = new XDocument(
                new XElement("Anwesenheitsliste",
                    new XElement("Schüler",
                        new XAttribute("Bereich", "ITA"),
                        new XElement("Name", "Fritz"),
                        new XElement("Nachname", "Müller"),
                        new XElement("Klasse", "AIF31")
                                )
                            )
                                          );
            doc.Save("anwesenheitsliste.xml");
        }

    }
}
