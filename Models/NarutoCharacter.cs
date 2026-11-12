using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SearchNarutoAPI.Models
{
    public class NarutoApiResponse
    {
        [JsonProperty("characters")]
        public List<NarutoCharacter>? Characters { get; set; }

        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class NarutoCharacter
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("images")]
        public List<string>? Images { get; set; }

        [JsonProperty("personal")]
        public PersonalInfo? Personal { get; set; }

        [JsonProperty("jutsu")]
        public List<string>? Jutsu { get; set; }

        [JsonProperty("rank")]
        public RankInfo? Rank { get; set; }

        /// <summary>
        /// Retorna a primeira imagem válida da lista ou uma imagem placeholder caso não possua.
        /// </summary>
        public string ObterImagemPrincipal()
        {
            if (Images != null && Images.Count > 0 && !string.IsNullOrWhiteSpace(Images[0]))
            {
                return Images[0];
            }
            return "https://via.placeholder.com/260x260?text=Sem+Imagem";
        }
    }

    public class PersonalInfo
    {
        [JsonProperty("clan")]
        public JToken? ClanToken { get; set; }

        [JsonProperty("affiliation")]
        public JToken? AffiliationToken { get; set; }

        public string ObterClan()
        {
            if (ClanToken == null) return string.Empty;
            if (ClanToken.Type == JTokenType.String)
                return ClanToken.ToString();
            if (ClanToken.Type == JTokenType.Array)
                return string.Join(", ", ClanToken.Select(t => t.ToString()));
            return ClanToken.ToString();
        }

        public string ObterAffiliation()
        {
            if (AffiliationToken == null) return string.Empty;
            if (AffiliationToken.Type == JTokenType.String)
                return AffiliationToken.ToString();
            if (AffiliationToken.Type == JTokenType.Array)
                return string.Join(", ", AffiliationToken.Select(t => t.ToString()));
            return AffiliationToken.ToString();
        }

        public string ObterClanOuAffiliation()
        {
            var clan = ObterClan();
            if (!string.IsNullOrWhiteSpace(clan))
            {
                return $"Clã {clan}";
            }

            var affiliation = ObterAffiliation();
            if (!string.IsNullOrWhiteSpace(affiliation))
            {
                return affiliation;
            }

            return "Não informado";
        }
    }

    public class RankInfo
    {
        [JsonProperty("ninjaRank")]
        public JToken? NinjaRankToken { get; set; }

        public string ObterNinjaRank()
        {
            if (NinjaRankToken == null) return "Não informado";

            if (NinjaRankToken.Type == JTokenType.String)
            {
                return NinjaRankToken.ToString();
            }

            if (NinjaRankToken.Type == JTokenType.Object && NinjaRankToken is JObject obj)
            {
                var partes = obj.Properties().Select(p => $"{p.Name}: {p.Value}");
                return string.Join(" | ", partes);
            }

            if (NinjaRankToken.Type == JTokenType.Array)
            {
                return string.Join(", ", NinjaRankToken.Select(t => t.ToString()));
            }

            return NinjaRankToken.ToString();
        }
    }
}
