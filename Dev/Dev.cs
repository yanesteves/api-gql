namespace Api.DEV
{
    [GraphQLDescription("Um objeto do tipo Developer")]
    public class Developer
    {
        [GraphQLDescription("Nome do responsável pela API.")]
        public string? Author { get; set; }
        [GraphQLDescription("Github do desenvolvedor.")]
        public string? Github { get; set; }
        [GraphQLDescription("Nome do curso que foi aplicado este conteúdo.")]
        public string? Course { get; set; }
    }
}