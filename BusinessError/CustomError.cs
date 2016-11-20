using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessError
{
    public class CustomError : Exception
    {
        private int _ID;
        private string _Message;

        public int ID {
            get { return _ID; }
                
        }
        public override string  Message {
            get { return _Message; }
        }

        // 1 -> Mauvais User
        // 2 -> Password Error
        // 3 -> Matricule < 5 caractères
        // 4 -> Matricule pour recherche minimum 3 caractères
        // 5 -> Etudiant non trouvé dans la DB...
        public CustomError( int pID )
        {
            string MyMessage;

            switch ( pID)
            {
                case 1:
                    MyMessage = "Le user n'est pas reconnu...";
                    break;
                case 3:
                    MyMessage = "le matricule doit être superieur à 4 caractères";
                    break;
                case 4:
                    MyMessage = "pour rechercher il faut au moins 3 caractères";
                    break;
                case 5:
                    MyMessage = "l'étudiant à modifier a déjà été supprimé ou n'existe pas";
                    break;
                case 6:
                    MyMessage = "aucune insertion n'a été effectuée";
                    break;
                case 7:
                    MyMessage = "l'id cours doit avoir au moins 4 caracteres";
                    break;
                case 8:
                    MyMessage = "des élèves suivent ce cours ,il ne peut donc être supprimmé";
                    break;
                case 9:
                    MyMessage = "vous ne pouvez update le cours que par le code ";
                    break;
                case 10:
                    MyMessage = "un cours avec cet id existe déjà";
                    break;
                case 11:
                    MyMessage = "cette ligne a déjà été modifié ,rechargez pour avoir les données actuelles";
                    break;
                default:
                    MyMessage = "Erreur non connue...";
                    _ID = 999;
                    break;
            }

            _Message = MyMessage;
        }

    }
}
