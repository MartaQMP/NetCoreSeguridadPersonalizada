using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NetCoreSeguridadPersonalizada.Filters
{
    public class AuthorizeUsersAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        /* ESTE METODO ES EL QUE PERMITERA IMPEDIR EL ACCESO A LOS ACTION/CONTROLLERS
         * EL FILTER SE ENCARGA DE INTERCEPTAR PETICIONES Y DECIDIR QUE HACER */
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            /* EL USUARIO QUE SE HA VALIDADO EN NUESTRA APP ESTARA DENTRO DE Context 
             * Y UNA PROPIEDAD LLAMADA User
             * CUALQUIER USER ESTA COMPUESTO POR DOS CARACTERISTICAS:
             * 1) Identity: EL NOMBRE DEL USUARIO Y SI ES ACTIVO
             * 2) Principal: EL ROLE DEL USUARIO */
            var user = context.HttpContext.User;
            /* EL FILTRO SOLAMENTE PREGUNTARA SI EXISTE EL USER SOLO ENTRA EN 
             * ACCION SI NO EXISTE */
            if(user.Identity.IsAuthenticated == false)
            {
                /* LO LLEVAMOS AL LOGIN SI NO SE HA AUTENTICADO, DEBEMOS 
                 * ENVIARLE UN CONTROLLER Y UN ACTION, TAMBIEN PODRIAMOS ENVIAR PARAM..
                 * controller=Home
                 * action=Privacy
                 * mensaje=Esto es un mensaje */
                RouteValueDictionary rutaLogin = new RouteValueDictionary
                    (new
                        {
                            controller="Managed",
                            action="LogIn"
                        }
                    );
                /* DEVOLVEMOS LA PETICION A LOGIN */
                context.Result = new RedirectToRouteResult(rutaLogin);
            }
        }
    }
}
