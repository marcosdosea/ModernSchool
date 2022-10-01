using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Core
{
    public partial class ModernSchoolContext : DbContext
    {
        public ModernSchoolContext()
        {
        }

        public ModernSchoolContext(DbContextOptions<ModernSchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alunoavaliacao> Alunoavaliacaos { get; set; }
        public virtual DbSet<Alunocomunicacao> Alunocomunicacaos { get; set; }
        public virtual DbSet<Anoletivo> Anoletivos { get; set; }
        public virtual DbSet<Avaliacao> Avaliacaos { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Componente> Componentes { get; set; }
        public virtual DbSet<Comunicacao> Comunicacaos { get; set; }
        public virtual DbSet<Curriculo> Curriculos { get; set; }
        public virtual DbSet<Diariodeclasse> Diariodeclasses { get; set; }
        public virtual DbSet<Escola> Escolas { get; set; }
        public virtual DbSet<Frequenciaaluno> Frequenciaalunos { get; set; }
        public virtual DbSet<Governo> Governos { get; set; }
        public virtual DbSet<Governoservidor> Governoservidors { get; set; }
        public virtual DbSet<Gradehorario> Gradehorarios { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Objetodeconhecimento> Objetodeconhecimentos { get; set; }
        public virtual DbSet<Objetodeconhecimentodiariodeclasse> Objetodeconhecimentodiariodeclasses { get; set; }
        public virtual DbSet<Periodo> Periodos { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Pessoacomunicacao> Pessoacomunicacaos { get; set; }
        public virtual DbSet<Turma> Turmas { get; set; }
        public virtual DbSet<Unidadetematica> Unidadetematicas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=ModernSchool");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alunoavaliacao>(entity =>
            {
                entity.HasKey(e => new { e.IdPessoa, e.IdAvaliacao })
                    .HasName("PRIMARY");

                entity.ToTable("alunoavaliacao");

                entity.HasIndex(e => e.IdAvaliacao, "fk_PessoaAvaliacao_Avaliacao1_idx");

                entity.HasIndex(e => e.IdPessoa, "fk_PessoaAvaliacao_Pessoa1_idx");

                entity.Property(e => e.IdPessoa)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idPessoa");

                entity.Property(e => e.IdAvaliacao)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idAvaliacao");

                entity.Property(e => e.Arquivo)
                    .IsRequired()
                    .HasColumnType("blob")
                    .HasColumnName("arquivo");

                entity.Property(e => e.DataEntrega).HasColumnName("dataEntrega");

                entity.Property(e => e.Nota)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("nota");

                entity.HasOne(d => d.IdAvaliacaoNavigation)
                    .WithMany(p => p.Alunoavaliacaos)
                    .HasForeignKey(d => d.IdAvaliacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PessoaAvaliacao_Avaliacao1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Alunoavaliacaos)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PessoaAvaliacao_Pessoa1");
            });

            modelBuilder.Entity<Alunocomunicacao>(entity =>
            {
                entity.HasKey(e => new { e.IdPessoa, e.IdComunicacao })
                    .HasName("PRIMARY");

                entity.ToTable("alunocomunicacao");

                entity.HasIndex(e => e.IdComunicacao, "fk_PessoaComunicacao_Comunicacao1_idx");

                entity.HasIndex(e => e.IdPessoa, "fk_PessoaComunicacao_Pessoa1_idx");

                entity.Property(e => e.IdPessoa)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idPessoa");

                entity.Property(e => e.IdComunicacao)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idComunicacao");

                entity.HasOne(d => d.IdComunicacaoNavigation)
                    .WithMany(p => p.Alunocomunicacaos)
                    .HasForeignKey(d => d.IdComunicacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PessoaComunicacao_Comunicacao1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Alunocomunicacaos)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PessoaComunicacao_Pessoa1");
            });

            modelBuilder.Entity<Anoletivo>(entity =>
            {
                entity.HasKey(e => e.AnoLetivo)
                    .HasName("PRIMARY");

                entity.ToTable("anoletivo");

                entity.HasIndex(e => e.IdEscola, "fk_AnoLetivo_Escola1_idx");

                entity.Property(e => e.AnoLetivo)
                    .HasColumnType("int unsigned")
                    .HasColumnName("anoLetivo");

                entity.Property(e => e.DataFim)
                    .HasColumnType("date")
                    .HasColumnName("dataFim");

                entity.Property(e => e.DataInicio)
                    .HasColumnType("date")
                    .HasColumnName("dataInicio");

                entity.Property(e => e.IdEscola)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idEscola");

                entity.HasOne(d => d.IdEscolaNavigation)
                    .WithMany(p => p.Anoletivos)
                    .HasForeignKey(d => d.IdEscola)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AnoLetivo_Escola1");
            });

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.ToTable("avaliacao");

                entity.HasIndex(e => e.IdComponente, "fk_Avaliacao_Componente1_idx");

                entity.HasIndex(e => e.IdPeriodo, "fk_Avaliacao_Periodo1_idx");

                entity.HasIndex(e => e.IdTurma, "fk_Avaliacao_Turma1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Avaliativo).HasColumnName("avaliativo");

                entity.Property(e => e.DataEntrega).HasColumnName("dataEntrega");

                entity.Property(e => e.HorarioEntrega).HasColumnName("horarioEntrega");

                entity.Property(e => e.IdComponente)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idComponente");

                entity.Property(e => e.IdPeriodo)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idPeriodo");

                entity.Property(e => e.IdTurma).HasColumnName("idTurma");

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.TipoDeAtividade)
                    .HasColumnType("enum('PROVA','PROJETO')")
                    .HasColumnName("tipoDeAtividade");

                entity.HasOne(d => d.IdComponenteNavigation)
                    .WithMany(p => p.Avaliacaos)
                    .HasForeignKey(d => d.IdComponente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Avaliacao_Componente1");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.Avaliacaos)
                    .HasForeignKey(d => d.IdPeriodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Avaliacao_Periodo1");

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.Avaliacaos)
                    .HasForeignKey(d => d.IdTurma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Avaliacao_Turma1");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo)
                    .HasName("PRIMARY");

                entity.ToTable("cargo");

                entity.Property(e => e.IdCargo).HasColumnName("idCargo");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Componente>(entity =>
            {
                entity.ToTable("componente");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Comunicacao>(entity =>
            {
                entity.ToTable("comunicacao");

                entity.HasIndex(e => e.IdComponente, "fk_Comunicacao_Componente1_idx");

                entity.HasIndex(e => e.IdTurma, "fk_Comunicacao_Turma1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.EnviarAlunos)
                    .HasColumnType("tinyint")
                    .HasColumnName("enviarAlunos");

                entity.Property(e => e.EnviarResponsaveis)
                    .HasColumnType("tinyint")
                    .HasColumnName("enviarResponsaveis");

                entity.Property(e => e.IdComponente)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idComponente");

                entity.Property(e => e.IdTurma).HasColumnName("idTurma");

                entity.Property(e => e.Mensagem)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("mensagem");

                entity.HasOne(d => d.IdComponenteNavigation)
                    .WithMany(p => p.Comunicacaos)
                    .HasForeignKey(d => d.IdComponente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Comunicacao_Componente1");

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.Comunicacaos)
                    .HasForeignKey(d => d.IdTurma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Comunicacao_Turma1");
            });

            modelBuilder.Entity<Curriculo>(entity =>
            {
                entity.ToTable("curriculo");

                entity.HasIndex(e => e.IdGoverno, "fk_Curriculo_Governo1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AnoFaixa)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("anoFaixa");

                entity.Property(e => e.AnoLetivo).HasColumnName("anoLetivo");

                entity.Property(e => e.Escolaridade)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("escolaridade")
                    .IsFixedLength(true);

                entity.Property(e => e.IdGoverno).HasColumnName("idGoverno");

                entity.HasOne(d => d.IdGovernoNavigation)
                    .WithMany(p => p.Curriculos)
                    .HasForeignKey(d => d.IdGoverno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Curriculo_Governo1");
            });

            modelBuilder.Entity<Diariodeclasse>(entity =>
            {
                entity.ToTable("diariodeclasse");

                entity.HasIndex(e => e.IdComponente, "fk_DiarioDeClasse_Componente1_idx");

                entity.HasIndex(e => e.IdProfessor, "fk_DiarioDeClasse_Pessoa1_idx");

                entity.HasIndex(e => e.IdTurma, "fk_DiarioDeClasse_Turma1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.DataShow).HasColumnName("dataShow");

                entity.Property(e => e.IdComponente)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idComponente");

                entity.Property(e => e.IdProfessor)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idProfessor");

                entity.Property(e => e.IdTurma).HasColumnName("idTurma");

                entity.Property(e => e.Livros).HasColumnName("livros");

                entity.Property(e => e.LivrosSeduc).HasColumnName("livrosSeduc");

                entity.Property(e => e.ResumoAula)
                    .HasMaxLength(100)
                    .HasColumnName("resumoAula");

                entity.Property(e => e.TipoAula)
                    .IsRequired()
                    .HasColumnType("enum('C','A')")
                    .HasColumnName("tipoAula")
                    .HasDefaultValueSql("'C'");

                entity.HasOne(d => d.IdComponenteNavigation)
                    .WithMany(p => p.Diariodeclasses)
                    .HasForeignKey(d => d.IdComponente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DiarioDeClasse_Componente1");

                entity.HasOne(d => d.IdProfessorNavigation)
                    .WithMany(p => p.Diariodeclasses)
                    .HasForeignKey(d => d.IdProfessor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DiarioDeClasse_Pessoa1");

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.Diariodeclasses)
                    .HasForeignKey(d => d.IdTurma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DiarioDeClasse_Turma1");
            });

            modelBuilder.Entity<Escola>(entity =>
            {
                entity.ToTable("escola");

                entity.HasIndex(e => e.Nome, "Nome_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdGoverno, "fk_Escola_Prefeitura_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(40)
                    .HasColumnName("bairro");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .HasColumnName("cnpj")
                    .IsFixedLength(true);

                entity.Property(e => e.IdGoverno).HasColumnName("idGoverno");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Rua)
                    .HasMaxLength(50)
                    .HasColumnName("rua");

                entity.HasOne(d => d.IdGovernoNavigation)
                    .WithMany(p => p.Escolas)
                    .HasForeignKey(d => d.IdGoverno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Escola_Prefeitura");
            });

            modelBuilder.Entity<Frequenciaaluno>(entity =>
            {
                entity.HasKey(e => new { e.IdPessoa, e.IdDiarioDeClasse })
                    .HasName("PRIMARY");

                entity.ToTable("frequenciaaluno");

                entity.HasIndex(e => e.IdDiarioDeClasse, "fk_PessoaDiarioDeClasse_DiarioDeClasse1_idx");

                entity.HasIndex(e => e.IdPessoa, "fk_PessoaDiarioDeClasse_Pessoa1_idx");

                entity.Property(e => e.IdPessoa)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idPessoa");

                entity.Property(e => e.IdDiarioDeClasse)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idDiarioDeClasse");

                entity.Property(e => e.Faltas).HasColumnName("faltas");

                entity.HasOne(d => d.IdDiarioDeClasseNavigation)
                    .WithMany(p => p.Frequenciaalunos)
                    .HasForeignKey(d => d.IdDiarioDeClasse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PessoaDiarioDeClasse_DiarioDeClasse1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Frequenciaalunos)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PessoaDiarioDeClasse_Pessoa1");
            });

            modelBuilder.Entity<Governo>(entity =>
            {
                entity.ToTable("governo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DependenciaAdministrativa)
                    .IsRequired()
                    .HasColumnType("enum('M','E')")
                    .HasColumnName("dependenciaAdministrativa")
                    .HasDefaultValueSql("'M'");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("municipio");
            });

            modelBuilder.Entity<Governoservidor>(entity =>
            {
                entity.HasKey(e => new { e.IdGoverno, e.IdPessoa })
                    .HasName("PRIMARY");

                entity.ToTable("governoservidor");

                entity.HasIndex(e => e.IdCargo, "fk_GovernoServidor_Cargo1_idx");

                entity.HasIndex(e => e.IdPessoa, "fk_GovernoServidor_Pessoa1_idx");

                entity.Property(e => e.IdGoverno).HasColumnName("idGoverno");

                entity.Property(e => e.IdPessoa)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idPessoa");

                entity.Property(e => e.DataFim)
                    .HasColumnType("date")
                    .HasColumnName("dataFim");

                entity.Property(e => e.DataInicio)
                    .HasColumnType("date")
                    .HasColumnName("dataInicio");

                entity.Property(e => e.IdCargo).HasColumnName("idCargo");

                entity.Property(e => e.Status)
                    .HasColumnType("enum('A','I')")
                    .HasColumnName("status");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Governoservidors)
                    .HasForeignKey(d => d.IdCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_GovernoServidor_Cargo1");

                entity.HasOne(d => d.IdGovernoNavigation)
                    .WithMany(p => p.Governoservidors)
                    .HasForeignKey(d => d.IdGoverno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_GovernoServidor_Governo1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Governoservidors)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_GovernoServidor_Pessoa1");
            });

            modelBuilder.Entity<Gradehorario>(entity =>
            {
                entity.ToTable("gradehorario");

                entity.HasIndex(e => e.IdComponente, "fk_ComponenteTurma_Componente1_idx");

                entity.HasIndex(e => e.IdTurma, "fk_ComponenteTurma_Turma1_idx");

                entity.HasIndex(e => e.IdProfessor, "fk_GradeHorario_Pessoa1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DiaSemana)
                    .IsRequired()
                    .HasColumnType("enum('SEG','TER')")
                    .HasColumnName("diaSemana");

                entity.Property(e => e.HoraFim)
                    .HasMaxLength(4)
                    .HasColumnName("horaFim");

                entity.Property(e => e.HoraInicio)
                    .HasMaxLength(4)
                    .HasColumnName("horaInicio");

                entity.Property(e => e.IdComponente)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idComponente");

                entity.Property(e => e.IdProfessor)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idProfessor");

                entity.Property(e => e.IdTurma).HasColumnName("idTurma");

                entity.HasOne(d => d.IdComponenteNavigation)
                    .WithMany(p => p.Gradehorarios)
                    .HasForeignKey(d => d.IdComponente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ComponenteTurma_Componente1");

                entity.HasOne(d => d.IdProfessorNavigation)
                    .WithMany(p => p.Gradehorarios)
                    .HasForeignKey(d => d.IdProfessor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_GradeHorario_Pessoa1");

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.Gradehorarios)
                    .HasForeignKey(d => d.IdTurma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ComponenteTurma_Turma1");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PRIMARY");

                entity.ToTable("habilidade");

                entity.HasIndex(e => e.IdObjetoDeConhecimento, "fk_Habilidade_ObjetoDeConhecimento1_idx");

                entity.Property(e => e.IdHabilidade)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idHabilidade");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdObjetoDeConhecimento)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idObjetoDeConhecimento");

                entity.HasOne(d => d.IdObjetoDeConhecimentoNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdObjetoDeConhecimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Habilidade_ObjetoDeConhecimento1");
            });

            modelBuilder.Entity<Objetodeconhecimento>(entity =>
            {
                entity.ToTable("objetodeconhecimento");

                entity.HasIndex(e => e.IdUnidadeTematica, "fk_ObjetoDeConhecimento_UnidadeTematica1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdUnidadeTematica)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idUnidadeTematica");

                entity.Property(e => e.SequenciaProposta).HasColumnName("sequenciaProposta");

                entity.HasOne(d => d.IdUnidadeTematicaNavigation)
                    .WithMany(p => p.Objetodeconhecimentos)
                    .HasForeignKey(d => d.IdUnidadeTematica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ObjetoDeConhecimento_UnidadeTematica1");
            });

            modelBuilder.Entity<Objetodeconhecimentodiariodeclasse>(entity =>
            {
                entity.HasKey(e => new { e.IdObjetoDeConhecimento, e.IdDiarioDeClasse })
                    .HasName("PRIMARY");

                entity.ToTable("objetodeconhecimentodiariodeclasse");

                entity.HasIndex(e => e.IdDiarioDeClasse, "fk_ObjetoDeConhecimentoDiarioDeClasse_DiarioDeClasse1_idx");

                entity.HasIndex(e => e.IdObjetoDeConhecimento, "fk_ObjetoDeConhecimentoDiarioDeClasse_ObjetoDeConhecimento1_idx");

                entity.Property(e => e.IdObjetoDeConhecimento)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idObjetoDeConhecimento");

                entity.Property(e => e.IdDiarioDeClasse)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idDiarioDeClasse");

                entity.HasOne(d => d.IdDiarioDeClasseNavigation)
                    .WithMany(p => p.Objetodeconhecimentodiariodeclasses)
                    .HasForeignKey(d => d.IdDiarioDeClasse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ObjetoDeConhecimentoDiarioDeClasse_DiarioDeClasse1");

                entity.HasOne(d => d.IdObjetoDeConhecimentoNavigation)
                    .WithMany(p => p.Objetodeconhecimentodiariodeclasses)
                    .HasForeignKey(d => d.IdObjetoDeConhecimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ObjetoDeConhecimentoDiarioDeClasse_ObjetoDeConhecimento1");
            });

            modelBuilder.Entity<Periodo>(entity =>
            {
                entity.ToTable("periodo");

                entity.HasIndex(e => e.AnoLetivo, "fk_Periodo_AnoLetivo1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AnoLetivo)
                    .HasColumnType("int unsigned")
                    .HasColumnName("anoLetivo");

                entity.Property(e => e.DataFim)
                    .HasColumnType("date")
                    .HasColumnName("dataFim");

                entity.Property(e => e.DataInicio)
                    .HasColumnType("date")
                    .HasColumnName("dataInicio");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nome");

                entity.HasOne(d => d.AnoLetivoNavigation)
                    .WithMany(p => p.Periodos)
                    .HasForeignKey(d => d.AnoLetivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Periodo_AnoLetivo1");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("pessoa");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(40)
                    .HasColumnName("bairro");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("cpf")
                    .IsFixedLength(true);

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("dataNascimento");

                entity.Property(e => e.Idade).HasColumnName("idade");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("nome");

                entity.Property(e => e.Numero)
                    .HasColumnType("smallint unsigned")
                    .HasColumnName("numero");

                entity.Property(e => e.Rua)
                    .HasMaxLength(50)
                    .HasColumnName("rua");
            });

            modelBuilder.Entity<Pessoacomunicacao>(entity =>
            {
                entity.HasKey(e => new { e.IdPessoa, e.IdComunicacao })
                    .HasName("PRIMARY");

                entity.ToTable("pessoacomunicacao");

                entity.HasIndex(e => e.IdComunicacao, "fk_PessoaComunicacao_Comunicacao2_idx");

                entity.HasIndex(e => e.IdPessoa, "fk_PessoaComunicacao_Pessoa2_idx");

                entity.Property(e => e.IdPessoa)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idPessoa");

                entity.Property(e => e.IdComunicacao)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idComunicacao");

                entity.HasOne(d => d.IdComunicacaoNavigation)
                    .WithMany(p => p.Pessoacomunicacaos)
                    .HasForeignKey(d => d.IdComunicacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PessoaComunicacao_Comunicacao2");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Pessoacomunicacaos)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PessoaComunicacao_Pessoa2");
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.ToTable("turma");

                entity.HasIndex(e => e.AnoLetivo, "fk_Turma_AnoLetivo1_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnoLetivo)
                    .HasColumnType("int unsigned")
                    .HasColumnName("anoLetivo");

                entity.Property(e => e.Escolaridade)
                    .IsRequired()
                    .HasColumnType("enum('F','I','M')")
                    .HasColumnName("escolaridade")
                    .HasDefaultValueSql("'F'");

                entity.Property(e => e.Sala)
                    .HasMaxLength(20)
                    .HasColumnName("sala");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('A','F')")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'A'");

                entity.Property(e => e.Turma1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("turma");

                entity.Property(e => e.Vagas)
                    .HasColumnType("int unsigned")
                    .HasColumnName("vagas");

                entity.Property(e => e.VagasDisponiveis).HasColumnName("vagasDisponiveis");

                entity.HasOne(d => d.AnoLetivoNavigation)
                    .WithMany(p => p.Turmas)
                    .HasForeignKey(d => d.AnoLetivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Turma_AnoLetivo1");
            });

            modelBuilder.Entity<Unidadetematica>(entity =>
            {
                entity.ToTable("unidadetematica");

                entity.HasIndex(e => e.IdComponente, "fk_UnidadeTematica_Componente1_idx");

                entity.HasIndex(e => e.IdCurriculo, "fk_UnidadeTematica_Curriculo1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AnoLetivo).HasColumnName("anoLetivo");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdComponente)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idComponente");

                entity.Property(e => e.IdCurriculo)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idCurriculo");

                entity.HasOne(d => d.IdComponenteNavigation)
                    .WithMany(p => p.Unidadetematicas)
                    .HasForeignKey(d => d.IdComponente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UnidadeTematica_Componente1");

                entity.HasOne(d => d.IdCurriculoNavigation)
                    .WithMany(p => p.Unidadetematicas)
                    .HasForeignKey(d => d.IdCurriculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UnidadeTematica_Curriculo1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
