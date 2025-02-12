using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Access.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChequeStatuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChequierStatuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientWarehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    GouvernoratId = table.Column<int>(type: "int", nullable: false),
                    VilleId = table.Column<int>(type: "int", nullable: false),
                    CiteId = table.Column<int>(type: "int", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientWarehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollaborateurRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborateurRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommandeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColisCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommandeEtapes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CommandeStautId = table.Column<int>(type: "int", nullable: false),
                    CommandeStautIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isAfficheClient = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandeEtat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommandeStatuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandeStatuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    CreationLe = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationLe = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreationPar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ModificationPar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ConsoleStatutId = table.Column<int>(type: "int", nullable: false),
                    ConsoleStatutIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    SocieteAgenceSourceId = table.Column<int>(type: "int", nullable: false),
                    SocieteAgenceDestinationId = table.Column<int>(type: "int", nullable: false),
                    SocieteAgenceSourceIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    SocieteAgenceDestinationIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CollaborateurId = table.Column<int>(type: "int", nullable: true),
                    VehiculeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsoleStatuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsoleStatuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmballageArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmballageArticles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacturationCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturationCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactureLignes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactureId = table.Column<int>(type: "int", nullable: false),
                    FactureArticleId = table.Column<int>(type: "int", nullable: false),
                    FactureArticleIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    FactureArticlePuHt = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    FactureArticlePuTtc = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    MontantHt = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    TaxeId = table.Column<int>(type: "int", nullable: false),
                    TaxeTaux = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    MontantTva = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    MontantTtc = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactureLignes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    MontantHt = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    MontantTva = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    MontantTpf = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    MontantTtc = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    CreationLe = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreationPar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ModificationLe = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModificationPar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FactureStatutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormulaireSatisfaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    NombreParticipants = table.Column<int>(type: "int", nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreationLe = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreationPar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulaireSatisfaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormulaireSatisfactionQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormulaireSatisfactionId = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "text", nullable: false),
                    FormulaireSatisfactionQuestionTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulaireSatisfactionQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormulaireSatisfactionQuestionsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulaireSatisfactionQuestionsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormulaireSatisfactionReponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormulaireSatisfactionId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    FormulaireSatisfactionQuestionId = table.Column<int>(type: "int", nullable: false),
                    FormulaireSatisfactionQuestion = table.Column<string>(type: "text", nullable: false),
                    Reponse = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulaireSatisfactionReponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gouvernorats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gouvernorats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventaireResultat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventaireId = table.Column<int>(type: "int", nullable: false),
                    CommandeId = table.Column<int>(type: "int", nullable: false),
                    CommandeNumero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CommandeNombrePiece = table.Column<int>(type: "int", nullable: false),
                    Ecart = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventaireResultat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    SocieteAgenceId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreationLe = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreationPar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    InventaireStatutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventaireStatuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventaireScan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventaireId = table.Column<int>(type: "int", nullable: false),
                    CommandeId = table.Column<int>(type: "int", nullable: false),
                    CommandeNumero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CommandeNombrePiece = table.Column<int>(type: "int", nullable: false),
                    CollaborateurId = table.Column<int>(type: "int", nullable: false),
                    DateScan = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventaireScan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventaireStatuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventaireStatutss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventaireStockTheorique",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventaireId = table.Column<int>(type: "int", nullable: false),
                    CommandeId = table.Column<int>(type: "int", nullable: false),
                    CommandeNumero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CommandeNombrePiece = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventaireStockTheorique", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogModificationStatutCommande",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommandeId = table.Column<int>(type: "int", nullable: false),
                    CommandeNumero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CommandeStatutActuelId = table.Column<int>(type: "int", nullable: false),
                    CommandeStatutActuelIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CommandeStatutModifierId = table.Column<int>(type: "int", nullable: false),
                    CommandeStatutModifierIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ModificationLe = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationPar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogModificationStatutCommande", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModesReglement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModesReglement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModesReglementFacturation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModesReglementFacturation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModesReglementPaiement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModesReglementPayout", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotifsCallCenter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotifsCallCenter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotifsLivraison",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isRetry = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotifsLivraison", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotifsPickup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotifsPickup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaiementDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaiementId = table.Column<int>(type: "int", nullable: false),
                    PaiementNumero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CommandeId = table.Column<int>(type: "int", nullable: false),
                    CommandeNumero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaiementDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paiements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ClientCode = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ClientIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    NombreCommande = table.Column<int>(type: "int", nullable: false),
                    PaiementStatutId = table.Column<int>(type: "int", nullable: false),
                    PaiementStatutIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CreationLe = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreationPar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ModificationLe = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationPar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ModeReglementPaiementId = table.Column<int>(type: "int", nullable: false),
                    ModeReglementPaiementIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    BanqueId = table.Column<int>(type: "int", nullable: true),
                    BanqueIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ChequierId = table.Column<int>(type: "int", nullable: true),
                    ChequeId = table.Column<int>(type: "int", nullable: true),
                    ChequeNumero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ClientRib = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NumeroTransaction = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Commentaire = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prospects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Abreviation = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NomCommercial = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    MatriculeFiscaleCin = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Gouvernorat = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Ville = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Adresse = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CodePostal = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Telephone = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    AdresseMail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NomPremierResponsable = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreationLe = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreationPar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prospects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReclamationCommentaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReclamationId = table.Column<int>(type: "int", nullable: false),
                    CollaborateurId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    CreationLe = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreationPar = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclamationCommentaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReclamationPriorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Couleur = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reclamations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommandeNumero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    SocieteDepartementId = table.Column<int>(type: "int", nullable: false),
                    SocieteDepartementIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ReclamationTypeId = table.Column<int>(type: "int", nullable: false),
                    ReclamationTypeIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ReclamationPrioriteId = table.Column<int>(type: "int", nullable: false),
                    ReclamationPrioriteIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ReclamationStatutId = table.Column<int>(type: "int", nullable: false),
                    ReclamationStatutIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CollaborateurId = table.Column<int>(type: "int", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ClientIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreationLe = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationLe = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreationPar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ModificationPar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    isCloture = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReclamationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    SocieteDepartementId = table.Column<int>(type: "int", nullable: false),
                    SocieteDepartementIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclamationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Societe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaisonSocial = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    MatriculeFiscale = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    RegistreCommerce = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Activite = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    NomCommercial = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Gouvernorat = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Ville = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Adresse = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CodePostal = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    AdresseMail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Telephone = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Secteur = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    PremierResponsable = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Marque = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Modele = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DateDerniereVisite = table.Column<DateOnly>(type: "date", nullable: true),
                    DateVignette = table.Column<DateOnly>(type: "date", nullable: true),
                    DateDernierVidange = table.Column<DateOnly>(type: "date", nullable: true),
                    Kilometrage = table.Column<int>(type: "int", nullable: false),
                    isGPS = table.Column<bool>(type: "bit", nullable: false),
                    VehiculeTypeId = table.Column<int>(type: "int", nullable: false),
                    VehiculeTypeIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreationLe = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationLe = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CreationPar = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationPar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PoidsMaximal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiculeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chequiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDebut = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    NumeroFin = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ChequierStatutId = table.Column<int>(type: "int", nullable: false),
                    ChequierStatutIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    BanqueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chequiers_Banques",
                        column: x => x.BanqueId,
                        principalTable: "Banques",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chequiers_ChequierStatuts",
                        column: x => x.ChequierStatutId,
                        principalTable: "ChequierStatuts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Villes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    GouvernoratId = table.Column<int>(type: "int", nullable: false),
                    GouvernoratIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Villes_Gouvernorats",
                        column: x => x.GouvernoratId,
                        principalTable: "Gouvernorats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Valeur = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    TaxeTypeId = table.Column<int>(type: "int", nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxesValeurAjoutee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxes_Taxes",
                        column: x => x.TaxeTypeId,
                        principalTable: "TaxeTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cheques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChequierId = table.Column<int>(type: "int", nullable: false),
                    BanqueId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ChequeStatutId = table.Column<int>(type: "int", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cheques_Banques",
                        column: x => x.BanqueId,
                        principalTable: "Banques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cheques_ChequeStatuts",
                        column: x => x.ChequeStatutId,
                        principalTable: "ChequeStatuts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cheques_Chequiers",
                        column: x => x.ChequierId,
                        principalTable: "Chequiers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    VilleId = table.Column<int>(type: "int", nullable: false),
                    VilleIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    GouvernoratId = table.Column<int>(type: "int", nullable: false),
                    GouvernoratIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cites_Gouvernorats",
                        column: x => x.GouvernoratId,
                        principalTable: "Gouvernorats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cites_Villes",
                        column: x => x.VilleId,
                        principalTable: "Villes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ZoneVilles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    GouvernoratId = table.Column<int>(type: "int", nullable: false),
                    VilleId = table.Column<int>(type: "int", nullable: false),
                    CiteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneVilles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZoneVilles_Cites",
                        column: x => x.CiteId,
                        principalTable: "Cites",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ZoneVilles_Gouvernorats",
                        column: x => x.GouvernoratId,
                        principalTable: "Gouvernorats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ZoneVilles_Villes",
                        column: x => x.VilleId,
                        principalTable: "Villes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ZoneVilles_Zones",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClientContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    NomComplet = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Fonction = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Telephone = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    AdresseMail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Note = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientContact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Abreviation = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NomCommercial = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    MatriculeFiscaleCin = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Gouvernorat = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Ville = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Adresse = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CodePostal = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Telephone = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    AdresseMail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    isAssujettiTva = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    isAssujettiTpf = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ServiceInitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    NombreTentativeLivraison = table.Column<int>(type: "int", nullable: false, defaultValue: 3),
                    CollaborateurId = table.Column<int>(type: "int", nullable: false),
                    CollaborateurName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isFacture = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Classe = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValue: "C"),
                    ModeReglementFacturationId = table.Column<int>(type: "int", nullable: false),
                    ModeReglementFacturationIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ModeReglementPaimentId = table.Column<int>(type: "int", nullable: false),
                    ModeReglementPaimentIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    FacturationCategorieId = table.Column<int>(type: "int", nullable: false),
                    FacturationCategorieIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    NombreJoursPaiement = table.Column<int>(type: "int", nullable: false),
                    DateFinContrat = table.Column<DateOnly>(type: "date", nullable: true),
                    isGenerationBonLivraison = table.Column<bool>(type: "bit", nullable: false),
                    ClientTypeId = table.Column<int>(type: "int", nullable: false),
                    ClientTypeIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    NomPremierResponsable = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ClientWarehouseId = table.Column<int>(type: "int", nullable: true),
                    ClientWarehouseIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    isStatPayout = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    isStatFacturation = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationLe = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationLe = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreationPar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ModificationPar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IsInterne = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_ClientTypes",
                        column: x => x.ClientTypeId,
                        principalTable: "ClientTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_ClientWarehouses",
                        column: x => x.ClientWarehouseId,
                        principalTable: "ClientWarehouses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_Clients",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_FacturationCategories",
                        column: x => x.FacturationCategorieId,
                        principalTable: "FacturationCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_ModesReglementFacturation",
                        column: x => x.ModeReglementFacturationId,
                        principalTable: "ModesReglementFacturation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_ModesReglementPaiement",
                        column: x => x.ModeReglementPaimentId,
                        principalTable: "ModesReglementPaiement",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_Services",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Collaborateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomComplet = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Cin = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Telephone = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    AdresseMail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Fonction = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RoleIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Adresse = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Gouvernorat = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CodePostal = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Ville = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationLe = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationLe = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreationPar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ModificationPar = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    isExterne = table.Column<bool>(type: "bit", nullable: false),
                    AgenceId = table.Column<int>(type: "int", nullable: false),
                    AgenceIntitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborateur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collaborateurs_CollaborateurRoles",
                        column: x => x.RoleId,
                        principalTable: "CollaborateurRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SocieteAgences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Gouvernorat = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Ville = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Adresse = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CodePostal = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Telephone = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    AdresseMail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CollaborateurId = table.Column<int>(type: "int", nullable: false),
                    CollaborateurName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    MatriculeFiscale = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocieteAgences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocieteAgences_Collaborateurs",
                        column: x => x.CollaborateurId,
                        principalTable: "Collaborateurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SocieteDepartements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isActif = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CollaborateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocieteDepartements_Collaborateurs",
                        column: x => x.CollaborateurId,
                        principalTable: "Collaborateurs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Societe",
                columns: new[] { "Id", "Activite", "Adresse", "AdresseMail", "CodePostal", "Gouvernorat", "MatriculeFiscale", "NomCommercial", "PremierResponsable", "RaisonSocial", "RegistreCommerce", "Secteur", "Telephone", "Ville" },
                values: new object[] { 1, "Livraison", "Lac2", "KoliZen@mail.com", "2025", "Tunis", "0000000/A/A/A/000", "KoliZen", "Fedi", "xxx", "xxxx", "x", "00000000", "Tunis" });

            migrationBuilder.CreateIndex(
                name: "IX_Cheques_BanqueId",
                table: "Cheques",
                column: "BanqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Cheques_ChequeStatutId",
                table: "Cheques",
                column: "ChequeStatutId");

            migrationBuilder.CreateIndex(
                name: "IX_Cheques_ChequierId",
                table: "Cheques",
                column: "ChequierId");

            migrationBuilder.CreateIndex(
                name: "IX_Chequiers_BanqueId",
                table: "Chequiers",
                column: "BanqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Chequiers_ChequierStatutId",
                table: "Chequiers",
                column: "ChequierStatutId");

            migrationBuilder.CreateIndex(
                name: "IX_Cites_GouvernoratId",
                table: "Cites",
                column: "GouvernoratId");

            migrationBuilder.CreateIndex(
                name: "IX_Cites_VilleId",
                table: "Cites",
                column: "VilleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientContacts_ClientId",
                table: "ClientContacts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientId",
                table: "Clients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientTypeId",
                table: "Clients",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientWarehouseId",
                table: "Clients",
                column: "ClientWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CollaborateurId",
                table: "Clients",
                column: "CollaborateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_FacturationCategorieId",
                table: "Clients",
                column: "FacturationCategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ModeReglementFacturationId",
                table: "Clients",
                column: "ModeReglementFacturationId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ModeReglementPaimentId",
                table: "Clients",
                column: "ModeReglementPaimentId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ServiceId",
                table: "Clients",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborateurs_AgenceId",
                table: "Collaborateurs",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborateurs_RoleId",
                table: "Collaborateurs",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SocieteAgences_CollaborateurId",
                table: "SocieteAgences",
                column: "CollaborateurId");

            migrationBuilder.CreateIndex(
                name: "IX_SocieteDepartements_CollaborateurId",
                table: "SocieteDepartements",
                column: "CollaborateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxes_TaxeTypeId",
                table: "Taxes",
                column: "TaxeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Villes_GouvernoratId",
                table: "Villes",
                column: "GouvernoratId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneVilles_CiteId",
                table: "ZoneVilles",
                column: "CiteId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneVilles_GouvernoratId",
                table: "ZoneVilles",
                column: "GouvernoratId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneVilles_VilleId",
                table: "ZoneVilles",
                column: "VilleId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneVilles_ZoneId",
                table: "ZoneVilles",
                column: "ZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientContacts_Clients",
                table: "ClientContacts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Collaborateurs",
                table: "Clients",
                column: "CollaborateurId",
                principalTable: "Collaborateurs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaborateurs_SocieteAgences",
                table: "Collaborateurs",
                column: "AgenceId",
                principalTable: "SocieteAgences",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocieteAgences_Collaborateurs",
                table: "SocieteAgences");

            migrationBuilder.DropTable(
                name: "Cheques");

            migrationBuilder.DropTable(
                name: "ClientContacts");

            migrationBuilder.DropTable(
                name: "CommandeCategories");

            migrationBuilder.DropTable(
                name: "CommandeEtapes");

            migrationBuilder.DropTable(
                name: "CommandeStatuts");

            migrationBuilder.DropTable(
                name: "Consoles");

            migrationBuilder.DropTable(
                name: "ConsoleStatuts");

            migrationBuilder.DropTable(
                name: "EmballageArticles");

            migrationBuilder.DropTable(
                name: "FactureLignes");

            migrationBuilder.DropTable(
                name: "Factures");

            migrationBuilder.DropTable(
                name: "FormulaireSatisfaction");

            migrationBuilder.DropTable(
                name: "FormulaireSatisfactionQuestions");

            migrationBuilder.DropTable(
                name: "FormulaireSatisfactionQuestionsTypes");

            migrationBuilder.DropTable(
                name: "FormulaireSatisfactionReponses");

            migrationBuilder.DropTable(
                name: "InventaireResultat");

            migrationBuilder.DropTable(
                name: "Inventaires");

            migrationBuilder.DropTable(
                name: "InventaireScan");

            migrationBuilder.DropTable(
                name: "InventaireStatuts");

            migrationBuilder.DropTable(
                name: "InventaireStockTheorique");

            migrationBuilder.DropTable(
                name: "LogModificationStatutCommande");

            migrationBuilder.DropTable(
                name: "ModesReglement");

            migrationBuilder.DropTable(
                name: "MotifsCallCenter");

            migrationBuilder.DropTable(
                name: "MotifsLivraison");

            migrationBuilder.DropTable(
                name: "MotifsPickup");

            migrationBuilder.DropTable(
                name: "PaiementDetails");

            migrationBuilder.DropTable(
                name: "Paiements");

            migrationBuilder.DropTable(
                name: "Prospects");

            migrationBuilder.DropTable(
                name: "ReclamationCommentaires");

            migrationBuilder.DropTable(
                name: "ReclamationPriorites");

            migrationBuilder.DropTable(
                name: "Reclamations");

            migrationBuilder.DropTable(
                name: "ReclamationTypes");

            migrationBuilder.DropTable(
                name: "Societe");

            migrationBuilder.DropTable(
                name: "SocieteDepartements");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "Vehicules");

            migrationBuilder.DropTable(
                name: "VehiculeTypes");

            migrationBuilder.DropTable(
                name: "ZoneVilles");

            migrationBuilder.DropTable(
                name: "ChequeStatuts");

            migrationBuilder.DropTable(
                name: "Chequiers");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "TaxeTypes");

            migrationBuilder.DropTable(
                name: "Cites");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "Banques");

            migrationBuilder.DropTable(
                name: "ChequierStatuts");

            migrationBuilder.DropTable(
                name: "ClientTypes");

            migrationBuilder.DropTable(
                name: "ClientWarehouses");

            migrationBuilder.DropTable(
                name: "FacturationCategories");

            migrationBuilder.DropTable(
                name: "ModesReglementFacturation");

            migrationBuilder.DropTable(
                name: "ModesReglementPaiement");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Villes");

            migrationBuilder.DropTable(
                name: "Gouvernorats");

            migrationBuilder.DropTable(
                name: "Collaborateurs");

            migrationBuilder.DropTable(
                name: "CollaborateurRoles");

            migrationBuilder.DropTable(
                name: "SocieteAgences");
        }
    }
}
