namespace APIEndereco.Domain
{
    public record Address
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string Ddd { get; set; }
        public string Siafi { get; set; }

        public Address()
        {

        }

        public Address(String Cep, String Logradouro, String Complemento, String Bairro, String Localidade, String Uf, String Ibge, String Gia, String Ddd, String Siafi)
        {
            this.Cep = Cep;
            this.Logradouro = Logradouro;
            this.Complemento = Complemento;
            this.Bairro = Bairro;
            this.Localidade = Localidade;
            this.Uf = Uf;
            this.Ibge = Ibge;
            this.Gia = Gia;
            this.Ddd = Ddd;
            this.Siafi = Siafi;
        }
    }
}
