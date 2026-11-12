# SearchNarutoAPI 🍥

Aplicação web desenvolvida em **Blazor WebAssembly (WASM)** (.NET 10+) para listar e buscar ninjas do universo de **Naruto** consumindo a API pública [Dattebayo API](https://dattebayo-api.onrender.com).

## 📋 Sobre o Projeto

Este projeto foi desenvolvido como atividade prática da disciplina de **Usabilidade, Desenvolvimento Web, Mobile e Jogos** (**Lista 25 - Blazor Naruto (Dattebayo API)**).

### Objetivos:
- Desenvolver uma aplicação SPA utilizando **Blazor WebAssembly** em **.NET 10+**.
- Consumir a **Dattebayo API** de forma assíncrona utilizando `HttpClient`.
- Implementar recursos de **busca por nome** e **listagem paginada** de ninjas.
- Exibir em cards responsivos os dados retornados pela API:
  - **Nome** (`name`)
  - **Imagem** (`images` — exibe ao menos uma imagem a partir da lista de URLs)
  - **Clã ou Afiliação** (`personal.clan` ou `personal.affiliation`)
  - **Lista de Jutsus** (`jutsu`)
  - **Patente Ninja** (`rank.ninjaRank`)

---

## 🚀 Funcionalidades

1. **Listagem Paginada de Ninjas:**
   - Carrega inicialmente a página 1 com os personagens principais (*Naruto Uzumaki, Sasuke Uchiha, etc.*).
   - Controles de paginação (**Anterior** e **Próxima**) com contador de páginas.
2. **Busca por Nome:**
   - Campo de texto para buscar qualquer personagem (Ex: *Naruto Uzumaki*, *Sasuke Uchiha*, *Sakura Haruno*, *Kakashi Hatake*, *Itachi Uchiha*).
   - Disparo por clique no botão **Buscar** ou pressionando a tecla **Enter**.
   - Atalhos de busca rápida com um clique.
3. **Cards Informativos com Todos os Campos Exigidos:**
   - Imagem oficial com estilo temático e fallback visual.
   - Nome do personagem e identificador (ID).
   - Clã ou afiliação ninja em badge destacado.
   - Patente ninja (Genin, Chunin, Jonin, etc.) formatada por fase.
   - Caixa com lista rolável contendo todos os **jutsus** do personagem e o total cadastrado.
4. **Tratamento de Exceções e Feedback Visual:**
   - Spinner animado durante o carregamento.
   - Mensagens de alerta caso o ninja não seja encontrado ou ocorra erro de conexão.

---

## 💻 Como Executar

### Pré-requisitos

- [.NET SDK 10+](https://dotnet.microsoft.com/download) instalado.

### Passos

1. Clone o repositório:
   ```bash
   git clone https://github.com/JoaoGargano/search-naruto-api.git
   ```

2. Acesse a pasta do projeto (onde fica o arquivo `.csproj`):
   ```bash
   cd search-naruto-api/SearchNarutoAPI
   ```

3. Execute a aplicação:
   ```bash
   dotnet run
   ```

4. Abra o navegador no endereço indicado no terminal (ex: `http://localhost:5xxx` ou `https://localhost:7xxx`).

---

## 🌐 Endpoints da API Utilizados

- **Base URL:** `https://dattebayo-api.onrender.com`
- **Listagem Paginada:**
  - `GET https://dattebayo-api.onrender.com/characters?page=1&limit=20`
- **Busca por Nome:**
  - `GET https://dattebayo-api.onrender.com/characters?name={nome}`
- **Consulta por ID:**
  - `GET https://dattebayo-api.onrender.com/characters/{id}`

### Exemplo de Retorno JSON:
```json
{
  "characters": [
    {
      "id": 1344,
      "name": "Naruto Uzumaki",
      "images": [
        "https://static.wikia.nocookie.net/naruto/images/d/d6/Naruto_Part_I.png"
      ],
      "personal": {
        "clan": "Uzumaki",
        "affiliation": ["Konohagakure", "Mount Myoboku"]
      },
      "rank": {
        "ninjaRank": {
          "Part I": "Genin",
          "Gaiden": "Kage"
        }
      },
      "jutsu": [
        "Rasengan",
        "Shadow Clone Technique"
      ]
    }
  ]
}
```

---

## 🛠️ Tecnologias Utilizadas

- **C#** / **.NET 10**
- **Blazor WebAssembly (Standalone App)**
- **HttpClient** (`GetStringAsync` e deserialização dinâmica)
- **Newtonsoft.Json** (`JToken` para manipulação flexível de estruturas dinâmicas)
- **Bootstrap 5** (Layout responsivo com tema personalizado)

---

## 📄 Licença

Este projeto está sob a licença [MIT](LICENSE).
