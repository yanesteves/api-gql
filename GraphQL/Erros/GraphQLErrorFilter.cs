namespace API 
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Message == "The current user is not authorized to access this resource.") {
                return error.WithCode("401").WithMessage(error.Message);
            }
            return error.WithMessage(error.Exception.Message);
        }
    }
}