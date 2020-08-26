
# Especificações de Requisitos de Gilded Rose

Bem-vindo ao time Gilded Rose. Como você deve saber, nós somos uma pequena pousada estrategicamente localizada em uma prestigiosa cidade, atendida pelo amigável atendente Allison. Além de ser uma pousada, nós também compramos e vendemos as mercadorias de melhor qualidade. Infelizmente nossas mercadorias vão perdendo a qualidade conforme chegam próximo sua data de venda.

Nós temos um sistema instalado que atualiza automaticamente os preços do nosso estoque. Esse sistema foi criado por um rapaz sem noção chamado Leeroy, que agora se dedica à novas aventuras. Seu trabalho será adicionar uma nova funcionalidade para o nosso sistema para que possamos vender uma nova categoria de itens. 

## Descrição preliminar

Vamos dar uma breve introdução do nosso sistema:

* Todos os itens (classe `Item`) possuem uma propriedade chamada `PrazoParaVenda` que informa o número de dias que temos para vende-lo
* Todos os itens possuem uma propriedade chamada `Qualidade` que informa o quão valioso é o item.
* No final do dia, nosso sistema decrementa os valores das propriedades `PrazoParaVenda` e `Qualidade` de cada um dos itens do estoque através do método `AtualizarQualidade`.

Bastante simples, não é? Bem, agora que as coisas ficam interessantes:

* Quando o (`PrazoParaVenda`) do item tiver passado, a (`Qualidade`) do item diminui duas vezes mais rápido.
* A (`Qualidade`) do item não pode ser negativa
* O (`Queijo Brie envelhecido`), aumenta sua qualidade (`Qualidade`) em `1` unidade a medida que envelhece.
* A (`Qualidade`) de um item não pode ser maior que 50.
* O item (`Dente do Tarrasque`), por ser um item lendário, não precisa ter um (`PrazoParaVenda`) e sua (`Qualidade`) não precisa ser diminuída.
* O item (`Ingressos`), assim como o (`Queijo Brie envelhecido`), aumenta sua (`Qualidade`) a medida que o  (`PrazoParaVenda`) se aproxima;
    * A (`Qualidade`) aumenta em `2` unidades quando o (`PrazoParaVenda`) é igual ou menor que `10`.
    * A (`Qualidade`) aumenta em `3` unidades quando o (`PrazoParaVenda`) é igual ou menor que `5`.
    * A (`Qualidade`) do item vai direto à `0` quando o (`PrazoParaVenda`) tiver passado.

Nós recentemente assinamos um suprimento de itens Conjurados Magicamente. Isto requer que nós atualizemos nosso sistema:

* Os itens "Conjurados" (`Conjurado`) diminuem a (`Qualidade`) duas vezes mais rápido que os outros itens.

Sinta-se livre para fazer qualquer alteração no método `AtualizarQualidade` e adicionar código novo contanto que tudo continue funcionando perfeitamente. Entretanto, não altere o código da classe `Item` ou da propriedade `Items` na classe `GildedRose` pois elas pertencem a um Goblin que irá te matar com um golpe pois ele não acredita na cultura de código compartilhado.

## Notas Finais

Para esclarecer: Um item não pode ter uma (`Qualidade`) maior que `50`, entretanto o  (`Dente do Tarrasque`) por ser um item lendário vai ter uma qualidade imutável de `80`.