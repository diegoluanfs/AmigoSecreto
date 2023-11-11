using System.Text;

namespace AmigoSecreto
{
    public partial class Form1 : Form
    {
        string url_arquivo = "D:/Diego/Projetos-2023/dotNet/AmigoSecreto/AmigoSecreto/amigo-secreto.txt";
        string url_arquivo_sorteado = "D:/Diego/Projetos-2023/dotNet/AmigoSecreto/AmigoSecreto/amigo-secreto-sorteado.txt";

        public Form1()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            dtView.CellContentClick += dtView_CellContentClick;
            btnAmigoSecreto.Click += btnAmigoSecreto_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarDadosNoDataGridView();
            AtualizarEstadoBtnSortear();
        }

        private void AtualizarEstadoBtnSortear()
        {
            if(ContarPessoasNoArquivo() >= 3)
            {
                btnSortear.Enabled = true;
                btnSortear.Visible = true;
            }
        }

        private void ConfigurarDataGridView()
        {
            dtView.ColumnCount = 3;
            dtView.Columns[0].Name = "Id";
            dtView.Columns[0].Visible = false;
            dtView.Columns[1].Name = "Nome";
            dtView.Columns[2].Name = "Telefone";

            DataGridViewButtonColumn btnExcluir = new DataGridViewButtonColumn();
            btnExcluir.Name = "Excluir";
            btnExcluir.Text = "Excluir";
            btnExcluir.UseColumnTextForButtonValue = true;
            dtView.Columns.Add(btnExcluir);

            dtView.CellContentClick += dtView_CellContentClick;
            dtView.CellEndEdit += dtView_CellEndEdit;
        }

        private void dtView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != dtView.Columns["Excluir"].Index && e.RowIndex >= 0)
            {
                string novoValor = dtView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                string id = dtView.Rows[e.RowIndex].Cells["Id"].Value.ToString();

                AtualizarLinhaNoArquivo(id, e.ColumnIndex, novoValor);
            }
        }

        private void AtualizarLinhaNoArquivo(string id, int colunaIndex, string novoValor)
        {
            try
            {
                string caminhoArquivo = url_arquivo;

                if (File.Exists(caminhoArquivo))
                {
                    string[] linhas = File.ReadAllLines(caminhoArquivo);

                    var linhaParaAtualizar = linhas.FirstOrDefault(linha => linha.StartsWith($"{id};"));

                    if (linhaParaAtualizar != null)
                    {
                        string[] colunas = linhaParaAtualizar.Split(';');
                        colunas[colunaIndex] = novoValor;

                        string novaLinha = string.Join(";", colunas);

                        for (int i = 0; i < linhas.Length; i++)
                        {
                            if (linhas[i].StartsWith($"{id};"))
                            {
                                linhas[i] = novaLinha;
                                break;
                            }
                        }
                        File.WriteAllLines(caminhoArquivo, linhas);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar linha no arquivo: {ex.Message}");
            }
        }

        private void CarregarDadosNoDataGridView()
        {
            try
            {
                string caminhoArquivo = url_arquivo;

                if (File.Exists(caminhoArquivo))
                {
                    string[] linhas = File.ReadAllLines(caminhoArquivo);

                    dtView.Rows.Clear();

                    foreach (var linha in linhas)
                    {
                        var colunas = linha.Split(';');
                        if (colunas.Length >= 3)
                        {
                            dtView.Rows.Add(colunas[0], colunas[1], colunas[2]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados no DataGridView: {ex.Message}");
            }
        }

        private void dtView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtView.Columns["Excluir"].Index && e.RowIndex >= 0)
            {
                string id = dtView.Rows[e.RowIndex].Cells["Id"].Value.ToString();

                dtView.Rows.RemoveAt(e.RowIndex);

                ExcluirLinhaDoArquivo(id);
            }
        }

        private void ExcluirLinhaDoArquivo(string id)
        {
            try
            {
                string caminhoArquivo = url_arquivo;

                if (File.Exists(caminhoArquivo))
                {
                    string[] linhas = File.ReadAllLines(caminhoArquivo);

                    var novasLinhas = linhas.Where(linha => !linha.StartsWith($"{id};"));

                    File.WriteAllLines(caminhoArquivo, novasLinhas);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir linha do arquivo: {ex.Message}");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string telefone = txtTelefone.Text;

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Por favor, insira um nome válido.");
                return;
            }

            if (!ValidarTelefone(telefone))
            {
                MessageBox.Show("Por favor, insira um número de telefone válido.");
                return;
            }

            int id = GerarIDUnico();
            string linha = $"{id};{nome};{telefone}";

            if (!ExisteIDNoArquivo(id))
            {
                SalvarEmArquivo(linha);

                txtNome.Text = string.Empty;
                txtTelefone.Text = string.Empty;

                CarregarDadosNoDataGridView();
            }
            else
            {
                MessageBox.Show($"O ID {id} já existe no arquivo. Por favor, tente novamente.");
            }
        }

        private int ContarPessoasNoArquivo()
        {
            try
            {
                string caminhoArquivo = url_arquivo;

                if (File.Exists(caminhoArquivo))
                {
                    string[] linhas = File.ReadAllLines(caminhoArquivo);
                    return linhas.Length;
                }

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao contar as pessoas no arquivo: {ex.Message}");
                return 0;
            }
        }

        private int GerarIDUnico()
        {
            return (int)DateTime.Now.Ticks;
        }

        private bool ExisteIDNoArquivo(int id)
        {
            try
            {
                string caminhoArquivo = url_arquivo;

                if (File.Exists(caminhoArquivo))
                {
                    // Lê todas as linhas do arquivo
                    string[] linhas = File.ReadAllLines(caminhoArquivo);

                    // Verifica se o ID já existe nas linhas
                    return linhas.Any(linha => linha.StartsWith($"{id};"));
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar o arquivo: {ex.Message}");
                return false;
            }
        }

        private bool ValidarTelefone(string telefone)
        {
            return !string.IsNullOrWhiteSpace(telefone);
        }

        private void SalvarEmArquivo(string linha)
        {
            try
            {
                string caminhoArquivo = url_arquivo;

                using (StreamWriter writer = new StreamWriter(caminhoArquivo, true))
                {
                    writer.WriteLine(linha);
                }

                // Limpar a lista de amigos sorteados e reativar o botão btnSortear
                LimparListaAmigosSorteados();
                btnSortear.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar no arquivo: {ex.Message}");
            }
        }

        private void LimparListaAmigosSorteados()
        {
            try
            {
                string caminhoArquivoSorteado = url_arquivo_sorteado;

                File.WriteAllText(caminhoArquivoSorteado, string.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao limpar lista de amigos sorteados: {ex.Message}");
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            MostrarListaSalva();
        }

        private void MostrarListaSalva()
        {
            try
            {
                string caminhoArquivo = url_arquivo;

                if (File.Exists(caminhoArquivo))
                {
                    string[] linhas = File.ReadAllLines(caminhoArquivo);

                    var nomesETelefones = linhas.Select(linha =>
                    {
                        var colunas = linha.Split(';');
                        if (colunas.Length >= 3)
                            return $"{colunas[1]}; {colunas[2]}";
                        else
                            return string.Empty;
                    }).Where(resultado => !string.IsNullOrEmpty(resultado));

                    string mensagem = "Lista de Nomes Salvos:\n" + string.Join("\n", nomesETelefones);

                    MessageBox.Show(mensagem);
                }
                else
                {
                    MessageBox.Show("O arquivo ainda não contém nomes salvos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao ler o arquivo: {ex.Message}");
            }
        }

        private void btnSortear_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> participantes = ObterParticipantes();
                if (participantes.Count < 3)
                {
                    MessageBox.Show("Número insuficiente de participantes para sortear.");
                    return;
                }

                List<string> amigosSecretos = SortearAmigos(participantes);
                SalvarAmigosSecretosEmArquivo(amigosSecretos);

                MessageBox.Show("Lista de sorteios construída com sucesso.");
                btnSortear.Enabled = false;
                btnAmigoSecreto.Visible = true;
                btnAmigoSecreto.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao sortear amigos secretos: {ex.Message}");
            }
        }

        private List<string> ObterParticipantes()
        {
            try
            {
                string caminhoArquivo = url_arquivo;
                List<string> participantes = new List<string>();

                if (File.Exists(caminhoArquivo))
                {
                    string[] linhas = File.ReadAllLines(caminhoArquivo);

                    foreach (var linha in linhas)
                    {
                        var colunas = linha.Split(';');
                        if (colunas.Length >= 3)
                        {
                            participantes.Add(colunas[1]);
                        }
                    }
                }

                return participantes;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter participantes: {ex.Message}");
            }
        }

        private List<string> SortearAmigos(List<string> participantes)
        {
            Random random = new Random();
            List<string> amigosSecretos = new List<string>();

            do
            {
                amigosSecretos = participantes.OrderBy(x => random.Next()).ToList();
            } while (!ValidarSorteio(participantes, amigosSecretos));



            return amigosSecretos;
        }

        private void SalvarAmigosSecretosEmArquivo(List<string> amigosSecretos)
        {
            try
            {
                string caminhoArquivoAmigosSecretos = url_arquivo_sorteado;

                using (StreamWriter writer = new StreamWriter(caminhoArquivoAmigosSecretos))
                {
                    for (int i = 0; i < amigosSecretos.Count; i++)
                    {
                        writer.Write(amigosSecretos[i]);

                        if (i < amigosSecretos.Count)
                        {
                            // Adicionar ; e o nome à direita
                            writer.Write(";" + amigosSecretos[(i + 1) % amigosSecretos.Count]);
                        }
                        else
                        {
                            // Se for a última linha, adicionar ; e o nome à direita da primeira linha
                            string[] nomes = amigosSecretos[0].Split(';');
                            if (nomes.Length == 2)
                            {
                                writer.Write($";{nomes[1]}");
                            }
                        }

                        // Quebrar linha
                        writer.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar amigos secretos em arquivo: {ex.Message}");
            }
        }

        private bool ValidarSorteio(List<string> participantes, List<string> amigosSecretos)
        {
            // Verifique se algum participante tirou ele mesmo como amigo secreto
            for (int i = 0; i < participantes.Count; i++)
            {
                if (participantes[i] == amigosSecretos[i])
                {
                    return false;
                }
            }

            // Verifique se nenhum participante ficou sem amigo secreto
            foreach (var participante in participantes)
            {
                if (!amigosSecretos.Any(amigo => amigo == participante))
                {
                    return false;
                }
            }

            return true;
        }

        private void btnAmigoSecreto_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> amigosSecretos = ObterAmigosSecretosDoArquivo();
                ExibirAmigosSecretoUmAPUm(amigosSecretos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exibir pares de amigos secretos: {ex.Message}");
            }
        }

        private List<string> ObterAmigosSecretosDoArquivo()
        {
            try
            {
                string caminhoArquivoAmigosSecretos = url_arquivo_sorteado;
                List<string> amigosSecretos = new List<string>();

                if (File.Exists(caminhoArquivoAmigosSecretos))
                {
                    string[] linhas = File.ReadAllLines(caminhoArquivoAmigosSecretos);
                    amigosSecretos.AddRange(linhas);
                }

                return amigosSecretos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter amigos secretos do arquivo: {ex.Message}");
            }
        }

        private void ExibirAmigosSecretoUmAPUm(List<string> amigosSecretos)
        {
            foreach (var amigoSecreto in amigosSecretos)
            {
                string[] nomes = amigoSecreto.Split(';');

                if (nomes.Length == 2)
                {
                    string nome1 = nomes[0];
                    string nome2 = nomes[1];

                    string mensagem = $"{nome1} tirou {nome2}";
                    MessageBox.Show(mensagem);
                }
                else
                {
                    MessageBox.Show("Formato incorreto ao exibir pares de amigos secretos.");
                }
            }
        }
    }
}