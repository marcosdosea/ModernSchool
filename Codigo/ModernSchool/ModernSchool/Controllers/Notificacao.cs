using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModernSchoolWEB.Controllers
{
    public class Notificacao : Controller
    {
        public enum Notifica
        {
            Sucesso,
            Erro,
            Informativo,
            Alerta
        }
        public void Notificar(string mensagem, Notifica alertType)
        {
            switch (alertType)
            {
                case Notifica.Sucesso:
                    TempData["alertType"] = "success";
                    TempData["alertIcon"] = "fa-solid fa-circle-check";
                    break;
                case Notifica.Erro:
                    TempData["alertType"] = "danger";
                    TempData["alertIcon"] = "fa-solid fa-circle-xmark";
                    break;
                case Notifica.Informativo:
                    TempData["alertType"] = "info";
                    TempData["alertIcon"] = "fa-solid fa-circle-info";
                    break;
                case Notifica.Alerta:
                    TempData["alertType"] = "warning";
                    TempData["alertIcon"] = "fa-solid fa-circle-exclamation";
                    break;
            }
            TempData["alertText"] = mensagem;
        }
    }
}
