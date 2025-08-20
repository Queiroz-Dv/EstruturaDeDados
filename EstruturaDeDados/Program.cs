Console.WriteLine("--- Catálogo de Produtos ---");


#region Conceito de Pilha
static void Pilha()
{
    Dictionary<string, Produto> catalogoRapido = new Dictionary<string, Produto>
    {
      { "P001", new Produto { Id = 1, Sku = "P001", Nome = "Café em Grãos", Preco = 25.50m } },
      { "P004", new Produto { Id = 4, Sku = "P004", Nome = "Coador de Pano", Preco = 12.30m } }
    };

    List<Produto> carrinhoDeCompras = new List<Produto>();
    Stack<Produto> historicoDeAdicoes = new Stack<Produto>();

    Console.WriteLine("\n--- Simulação de Venda com Função Desfazer ---");

    // Adicionando itens
    AdicionarItemAoCarrinho("P001", carrinhoDeCompras, historicoDeAdicoes, catalogoRapido);
    AdicionarItemAoCarrinho("P004", carrinhoDeCompras, historicoDeAdicoes, catalogoRapido);

    Console.WriteLine($"Itens no carrinho: {carrinhoDeCompras.Count}. Itens no histórico: {historicoDeAdicoes.Count}");
    ExibirCarrinho(carrinhoDeCompras);

    // O operador percebe um erro e clica em "Desfazer"
    Console.WriteLine("\n** Acionando Desfazer **");
    DesfazerUltimaAdicao(carrinhoDeCompras, historicoDeAdicoes);

    Console.WriteLine($"Itens no carrinho: {carrinhoDeCompras.Count}. Itens no histórico: {historicoDeAdicoes.Count}");
    ExibirCarrinho(carrinhoDeCompras);
}
#region Métodos Auxiliares da pilha
// Função auxiliar para adicionar item, agora atualizando o histórico
static void AdicionarItemAoCarrinho(string sku, List<Produto> carrinho, Stack<Produto> historico, Dictionary<string, Produto> catalogo)
{
    if (catalogo.TryGetValue(sku, out var produto))
    {
        carrinho.Add(produto);
        historico.Push(produto); // Empilha a ação para possível 'undo'
        Console.WriteLine($"Adicionado: {produto.Nome}");
    }
}

// Função para Desfazer a última adição
static void DesfazerUltimaAdicao(List<Produto> carrinho, Stack<Produto> historico)
{
    if (historico.Count > 0)
    {
        Produto ultimoAdicionado = historico.Pop(); // Desempilha a última ação
        carrinho.Remove(ultimoAdicionado); // Reverte a ação no carrinho
        Console.WriteLine($"Desfeito: remoção de '{ultimoAdicionado.Nome}'");
    }
    else
    {
        Console.WriteLine("Nada para desfazer.");
    }
}

static void ExibirCarrinho(List<Produto> carrinho)
{
    Console.WriteLine("Itens atuais no carrinho:");
    foreach (var item in carrinho)
    {
        Console.WriteLine($"- {item.Nome}");
    }
}
#endregion
#endregion

#region Conceito de Filas
static void Filas()
{
    Queue<Pedido> filaDeProcessamento = new Queue<Pedido>();

    Console.WriteLine("\n--- Novos Pedidos Online Chegando ---");
    // Novos pedidos são "enfileirados" com Enqueue()
    filaDeProcessamento.Enqueue(new Pedido { Id = 1001, DataHora = DateTime.Now });
    Console.WriteLine($"Pedido 1001 entrou na fila. Total na fila: {filaDeProcessamento.Count}");

    Thread.Sleep(50); // Simula um pequeno atraso

    filaDeProcessamento.Enqueue(new Pedido { Id = 1002, DataHora = DateTime.Now });
    Console.WriteLine($"Pedido 1002 entrou na fila. Total na fila: {filaDeProcessamento.Count}");

    Thread.Sleep(50);

    filaDeProcessamento.Enqueue(new Pedido { Id = 1003, DataHora = DateTime.Now });
    Console.WriteLine($"Pedido 1003 entrou na fila. Total na fila: {filaDeProcessamento.Count}");

    Console.WriteLine("\n--- Processando Pedidos do Estoque (FIFO) ---");
    // O processamento ocorre enquanto houver itens na fila
    while (filaDeProcessamento.Count > 0)
    {
        // Dequeue() remove e retorna o item mais antigo (o primeiro que entrou)
        Pedido pedidoAtual = filaDeProcessamento.Dequeue();
        Console.WriteLine($"Processando Pedido ID: {pedidoAtual.Id} (Recebido em: {pedidoAtual.DataHora.ToLongTimeString()})");
        Console.WriteLine($"Pedidos restantes na fila: {filaDeProcessamento.Count}\n");
        // Aqui ocorreria a lógica de negócio para separar os produtos do pedido
    }
    Console.WriteLine("Fila de pedidos vazia. Todos os pedidos foram processados.");
}
#endregion

#region Conceito de HashSets
static void HashSets()
{
    var catalogoRapido = new Dictionary<string, Produto>() { { "P001", new Produto { Id = 1, Sku = "P001", Nome = "Café em Grãos", Preco = 25.50m } } };

    // 1. Gerenciando Tags de Produto
    Console.WriteLine("--- Gerenciando Tags ---");
    if (catalogoRapido.TryGetValue("P001", out var cafe))
    {
        cafe.Tags.Add("Promoção");
        cafe.Tags.Add("Orgânico");

        // Tentar adicionar uma tag duplicada
        bool adicionouDuplicado = cafe.Tags.Add("Promoção"); // Este método retornará 'false'

        Console.WriteLine($"Tentativa de adicionar 'Promoção' novamente. Sucesso? {adicionouDuplicado}");
        Console.WriteLine($"Tags do Café: {string.Join(", ", cafe.Tags)}"); // Saída: Promoção, Orgânico
    }

    // 2. Rastreando Clientes Únicos
    Console.WriteLine("\n--- Rastreando Clientes do Dia ---");
    HashSet<int> clientesUnicosDoDia = new HashSet<int>();

    // Simulando algumas vendas de diferentes clientes
    clientesUnicosDoDia.Add(101); // Cliente 101 comprou
    Console.WriteLine("Cliente 101 fez uma compra.");

    clientesUnicosDoDia.Add(205); // Cliente 205 comprou
    Console.WriteLine("Cliente 205 fez uma compra.");

    // O cliente 101 faz outra compra. O HashSet ignora a duplicata.
    clientesUnicosDoDia.Add(101);
    Console.WriteLine("Cliente 101 fez outra compra.");

    Console.WriteLine($"\nTotal de clientes únicos hoje: {clientesUnicosDoDia.Count}"); // Saída: 2
    Console.WriteLine($"IDs dos clientes únicos: {string.Join(", ", clientesUnicosDoDia)}");
}
#endregion

#region Conceito de Dicionários
static void Dicionarios()
{
    // Partimos da lista de produtos criada anteriormente
    Dictionary<string, Produto> catalogoRapido = new Dictionary<string, Produto>
    {
        { "P001", new Produto { Id = 1, Sku = "P001", Nome = "Café em Grãos", Preco = 25.50m } },
        { "P003", new Produto { Id = 3, Sku = "P003", Nome = "Açúcar Mascavo", Preco = 8.00m } },
        { "P004", new Produto { Id = 4, Sku = "P004", Nome = "Coador de Pano", Preco = 12.30m } }
    }.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);


    List<Produto> carrinhoDeCompras = new List<Produto>();
    List<string> skusLidos = new List<string>() { "P001", "P003", "SKU_INEXISTENTE", "P004" };

    Console.WriteLine("\n--- Registrando Venda ---");
    foreach (var sku in skusLidos)
    {
        // TryGetValue é a forma mais segura de acessar um dicionário.
        // Ele retorna 'true' se a chave existe e preenche a variável 'out'.
        // Retorna 'false' se a chave não existe, sem causar um erro.
        if (catalogoRapido.TryGetValue(sku, out Produto? produtoEncontrado))
        {
            carrinhoDeCompras.Add(produtoEncontrado);
            Console.WriteLine($"Adicionado ao carrinho: {produtoEncontrado.Nome} (R$ {produtoEncontrado.Preco})");
        }
        else
        {
            Console.WriteLine($"ERRO: Produto com SKU '{sku}' não encontrado no catálogo.");
        }
    }
}
#endregion

#region Conceito de Listas
static void ListasDinamicas()
{
    Console.WriteLine();

    // Agora, em vez de múltiplos arrays, temos uma única lista de objetos Produto.
    List<Produto> catalogo = new List<Produto>
    {
        new Produto { Id = 1, Nome = "Café em Grãos", Preco = 25.50m },
        new Produto { Id = 2, Nome = "Filtro de Papel", Preco = 5.80m },
        new Produto { Id = 3, Nome = "Açúcar Mascavo", Preco = 8.00m }
    };

    Console.WriteLine("--- Catálogo Inicial ---");
    foreach (var produto in catalogo)
    {
        Console.WriteLine($"ID: {produto.Id}, Produto: {produto.Nome}, Preço: R$ {produto.Preco}");
    }

    Console.WriteLine("\n--- Adicionando novo produto ---");
    // Adicionar um novo item é uma simples chamada de método.
    catalogo.Add(new Produto { Id = 4, Nome = "Coador de Pano", Preco = 12.30m });
    Console.WriteLine("'Coador de Pano' adicionado.");

    Console.WriteLine("\n--- Removendo 'Filtro de Papel' ---");
    // Para remover, primeiro precisamos encontrar o objeto.
    // O método Find() usa uma expressão lambda para definir a condição de busca.
    Produto? produtoParaRemover = catalogo.Find(p => p.Nome == "Filtro de Papel");

    if (produtoParaRemover != null)
    {
        catalogo.Remove(produtoParaRemover);
        Console.WriteLine("Produto removido com sucesso.");
    }

    Console.WriteLine("\n--- Catálogo Atualizado ---");
    foreach (var produto in catalogo)
    {
        Console.WriteLine($"ID: {produto.Id}, Produto: {produto.Nome}, Preço: R$ {produto.Preco}");
    }
}
#endregion

#region Conceito de Matrizes
static void MatrizesBasico()
{
    // Mantemos o array de nomes de produtos do capítulo anterior
    string[] nomesProdutos = ObterNomesProdutos();
    int[,] estoqueProdutos = { { 50, 30 }, { 120, 80 }, { 85, 45 } };

    Console.WriteLine("--- Relatório de Estoque ---");
    // O laço externo itera sobre as linhas (produtos)
    for (int i = 0; i < estoqueProdutos.GetLength(0); i++)
    {
        int estoqueTotalProduto = 0;
        // O nome do produto é obtido do array paralelo usando o mesmo índice de linha 'i'
        Console.WriteLine($"Produto: {nomesProdutos[i]}");

        // O laço interno itera sobre as colunas (filiais)
        for (int j = 0; j < estoqueProdutos.GetLength(1); j++)
        {
            int estoqueAtual = estoqueProdutos[i, j];
            estoqueTotalProduto += estoqueAtual;
            Console.WriteLine($"  - Filial {j}: {estoqueAtual} unidades");
        }
        Console.WriteLine($"  - Estoque Total do Produto: {estoqueTotalProduto} unidades\n");
    }
}
#endregion

#region Conceito de Array
static void ArrayBasico()
{
    string[] nomesProdutos = ObterNomesProdutos();
    decimal[] precosProdutos = ObterPrecosProdutos();

    // O produto em nomesProdutos[i] tem o preço definido em precosProdutos[i]

    // O laço 'for' itera de 0 até o comprimento do array - 1
    for (int i = 0; i < nomesProdutos.Length; i++)
    {
        // Usamos o mesmo índice 'i' para acessar elementos correspondentes em ambos os arrays
        // Se o índice não for o último número do array paralelo eu imprimo tudo junto
        if (i != precosProdutos.Length)
        {
            Console.WriteLine($"Produto: {nomesProdutos[i]}, Preço: R$ {precosProdutos[i]}");
        }
    }
}
#endregion

#region Métodos Auxiliares

static decimal[] ObterPrecosProdutos()
{
    // Declaração e inicialização de um array de decimais usando a sintaxe curta
    return [25.50m, 5.80m, 8.00m];
}

static string[] ObterNomesProdutos()
{
    // Declaração de um array de strings com tamanho fixo 3
    return ["Café em Grãos", "Filtro de Papel", "Açúcar Mascavo"];
}

#endregion