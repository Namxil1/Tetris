using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class ModelXML : IModel
    {
        IView IModel.View { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IController IModel.Controller { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        int IModel.getHighscore(int ID)
        {
            throw new NotImplementedException();
        }

        string IModel.getName(int ID)
        {
            throw new NotImplementedException();
        }

        int IModel.GetUserID(string username, string pwd)
        {
            throw new NotImplementedException();
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

        }

    }
}
