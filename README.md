# Projeto: Fundamentos de Estruturas de Dados com C\#

Este repositório serve como um guia prático para o estudo e a compreensão das estruturas de dados fundamentais em C\#. Ele oferece exemplos de código claros e comentados que demonstram a aplicação de cada estrutura em cenários do mundo real, como gerenciamento de estoque e processamento de pedidos.

O objetivo é fornecer uma base sólida para desenvolvedores em início de carreira e estudantes de ciência da computação, ajudando-os a entender não apenas a sintaxe, mas também a lógica e o propósito de cada estrutura de dados.

## Estrutura do Projeto e Tópicos Abordados

Os exemplos estão organizados para que você possa explorar cada conceito individualmente. A classe `Produto.cs` é utilizada em vários exemplos para simular dados de um catálogo de produtos, tornando o aprendizado mais contextualizado e prático.

### Matrizes e Arrays
* **Arrays:** Coleções de tamanho fixo para armazenar elementos do mesmo tipo.
* **Matrizes:** Estruturas bidimensionais úteis para organizar dados em linhas e colunas, como em um relatório de estoque.

### Listas Dinâmicas
* **`List<T>`:** Uma coleção flexível cujo tamanho pode ser ajustado dinamicamente, permitindo adicionar ou remover itens com facilidade.

### Estruturas de Coleção Otimizadas
* **Dicionários (`Dictionary<TKey, TValue>`):** Estrutura de dados que armazena pares de chave-valor, ideal para buscas rápidas.
* **Conjuntos de Hash (`HashSet<T>`):** Coleção que garante a unicidade de seus elementos, perfeita para rastrear itens sem duplicatas, como clientes únicos.

### Pilhas e Filas
* **Filas (`Queue<T>`):** Uma coleção que opera no princípio FIFO (First-In, First-Out). O primeiro item a ser adicionado é o primeiro a ser removido, como em uma fila de pedidos.
* **Pilhas (`Stack<T>`):** Uma coleção que segue o princípio LIFO (Last-In, First-Out). O último item a ser adicionado é o primeiro a ser removido, sendo ideal para funcionalidades como "desfazer" ações.

## Como Iniciar

1.  Clone este repositório para a sua máquina local.
2.  Abra a solução `EstruturaDeDados.sln` no Visual Studio.
3.  Abra o arquivo `Program.cs` para visualizar os exemplos de código.
4.  Descomente o método que você deseja executar para ver o resultado no console.

```csharp
// Exemplo: Executa a demonstração de pilhas
// Pilha();

// Exemplo: Executa a demonstração de filas
// Filas();
