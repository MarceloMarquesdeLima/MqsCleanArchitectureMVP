# Projetos Clean Architecture para seguimento Bancário

Este roadmap que organiza a implementação de um MVP bancário utilizando os princípios da Clean Architecture, garantindo separação de responsabilidades, escalabilidade e segurança.

1. Core Financeiro (Domínio)
   * Ledger (livro razão digital): Implementar entidades e regras de negócio para registrar transações.
   * Gestão de contas e saldos: MVP que valida operações básicas de débito e crédito.
   * Fluxo de pagamentos (PIX, TED, DOC): Casos de uso que orquestram transferências.

2. Segurança e Autenticação
   * Serviço de autenticação multifator (MFA): Implementado como caso de uso separado, desacoplado da infraestrutura.
   * Tokenização e criptografia: Regras de negócio independentes de frameworks externos.
   * Antifraude básico: MVP com regras simples de validação de transações suspeitas.
     
3. Integração com APIs e Open Finance
   * Gateway de APIs bancárias: MVP que expõe endpoints REST/GraphQL para saldo, extrato e transferências.
   * Integração com BACEN/PIX: Infra layer que conecta serviços externos sem poluir regras de negócio.
   * Open Finance: MVP que consome dados externos via adaptadores.
     
4. Observabilidade e Infraestrutura
   * Logs e auditoria: MVP com casos de uso que registram eventos críticos.
   * Monitoramento básico: Adaptadores para métricas de performance e alertas.
   * Deploy em nuvem (Docker/Kubernetes): Infra layer para validar escalabilidade.
  
5. Docker Compose para desenvolvimento local
   * Containers para SQL Server, MongoDB, Kafka, Zookeeper.
   * API e serviços rodando em containers independentes.
6. Kubernetes (K8s) para produção
   * Deploy com Helm Charts.
   * ConfigMaps e Secrets para credenciais.
   * Horizontal Pod Autoscaler (HPA) para escalar serviços de leitura/escrita.
   * Observabilidade com Prometheus + Grafana.
     
<img width="1024" height="1536" alt="Copilot_20260423_060651" src="https://github.com/user-attachments/assets/62c6d17d-8405-446b-adf5-ea703ffd8384" />

#### O diagrama de domínio bancário que integra as Entidades, Aggregates, Events, Interfaces e Value Objects em uma visão única.

<img width="1536" height="1024" alt="Copilot_20260423_085455" src="https://github.com/user-attachments/assets/b942e951-1949-45ee-9feb-5c7ebf47dc78" />

## O diagrama mostra:

🟧 Account Aggregate — o agregado raiz que contém a entidade Account e a lista de Transactions.

🔵 Account (Entidade) — atributos como AccountId, HolderName, Balance e métodos Deposit e Withdraw.

🟩 Money (Value Object) — imutável, com operações Add e Subtract.

⚪ Transaction (Entidade) — registra movimentações financeiras vinculadas à conta.

🟨 Domain Events — AccountCreatedEvent e FundsTransferredEvent, disparados pelas entidades.

➡️ Interfaces — contratos como IAccountRepository, ITransactionRepository e IEventPublisher que conectam o domínio à infraestrutura.

Esse diagrama é essencial para documentar o núcleo do domínio e mostrar como os componentes se relacionam de forma clara e consistente.

## o diagrama completo da arquitetura do MVP bancário, integrando todas as camadas — Domain, Application, Infrastructure e API — em uma visão única e coesa.

<img width="1024" height="1536" alt="BCO 4c69f751-018b-4e26-a132-e7f361316f23" src="https://github.com/user-attachments/assets/eeaebe03-ecf4-4e96-9904-00171562f567" />

O diagrama mostra:

🧭 Camada API — com o AccountController, responsável por receber requisições HTTP e acionar os comandos e queries.

⚙️ Camada Application — contendo Commands, Handlers e Queries, que orquestram a lógica de negócio e comunicação com o domínio.

🧩 Camada Domain — com Entities, Aggregates, Events e Value Objects, representando o núcleo da regra de negócio.

🏗️ Camada Infrastructure — com Repositories, Messaging (Kafka) e Databases (SQL Server e MongoDB), responsáveis pela persistência e mensageria.

🔄 Fluxos de comunicação — setas indicam o caminho das chamadas API, manipulação de comandos e queries, e publicação de eventos.

Esse diagrama é ideal para documentação técnica, onboarding de desenvolvedores e apresentações de arquitetura.

O diagrama mostra:

🐳 Docker Containers — cada serviço (API, Kafka, SQL Server, MongoDB) empacotado com suas dependências.

☸️ Kubernetes Cluster — orquestra os pods e serviços, garantindo escalabilidade e alta disponibilidade.

🔄 Kafka Broker — gerencia eventos e mensagens entre os microserviços.

🗄️ SQL Server Pod — armazena dados transacionais.

🍃 MongoDB Pod — mantém snapshots e dados de leitura rápida.

### Esse diagrama é ideal para documentação de infraestrutura e DevOps, mostrando como o sistema se comporta em produção.

🌐 API Pod — expõe endpoints REST e se comunica com Kafka e bancos.

📦 ConfigMaps e Secrets — armazenam variáveis de ambiente e credenciais seguras.

🧭 Ingress Controller — gerencia o tráfego externo para a API.

#### Os arquivos colocados na pasta k8s/ do projeto e aplicados com o seguinte comando:
kubectl apply -f k8s/
