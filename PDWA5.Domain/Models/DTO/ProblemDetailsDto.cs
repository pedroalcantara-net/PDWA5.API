namespace PDWA5.Domain.Models.DTO
{
    /// <summary>
    /// Tipo para retorno de status HTTP diferentes dos esperados (200, 201, 204), informando mais detalhes sobre a ocorrência.
    /// </summary>
    public class ProblemDetailsDto
    {
        /// <summary>
        /// Informa se a requisição foi realizada com sucesso ou se houve um erro em sua execução.
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Informa mais detalhes sobre a ocorrência.
        /// </summary>
        public string Message { get; set; }

        public static ProblemDetailsDto Success(string message)
        {
            return new ProblemDetailsDto()
            {
                IsSuccess = true,
                Message = message
            };
        }

        public static ProblemDetailsDto Error(string message)
        {
            return new ProblemDetailsDto()
            {
                IsSuccess = false,
                Message = message
            };
        }
    }
}
