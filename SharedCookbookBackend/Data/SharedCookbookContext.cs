using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SharedCookbookBackend.Models;

namespace SharedCookbookBackend.Data;

public partial class SharedCookbookContext : DbContext
{
    public SharedCookbookContext()
    {
    }

    public SharedCookbookContext(DbContextOptions<SharedCookbookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cookbook> Cookbooks { get; set; }

    public virtual DbSet<CookbookInvitation> CookbookInvitations { get; set; }

    public virtual DbSet<CookbookMember> CookbookMembers { get; set; }

    public virtual DbSet<CookbookNotification> CookbookNotifications { get; set; }

    public virtual DbSet<IngredientCategory> IngredientCategories { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeComment> RecipeComments { get; set; }

    public virtual DbSet<RecipeDirection> RecipeDirections { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public virtual DbSet<RecipeRating> RecipeRatings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=SharedCookbook;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cookbook>(entity =>
        {
            entity.HasKey(e => e.CookbookId).HasName("PK__cookbook__A4D8BA68B6C0F28D");

            entity.ToTable("cookbook");

            entity.Property(e => e.CookbookId).HasColumnName("cookbook_id");
            entity.Property(e => e.CoverAccentColor)
                .HasMaxLength(255)
                .HasColumnName("cover_accent_color");
            entity.Property(e => e.CoverColor)
                .HasMaxLength(255)
                .HasColumnName("cover_color");
            entity.Property(e => e.CoverFont)
                .HasMaxLength(255)
                .HasColumnName("cover_font");
            entity.Property(e => e.CoverPattern)
                .HasMaxLength(255)
                .HasColumnName("cover_pattern");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .HasColumnName("image_path");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Person).WithMany(p => p.Cookbooks)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__cookbook__person__1AD3FDA4");
        });

        modelBuilder.Entity<CookbookInvitation>(entity =>
        {
            entity.HasKey(e => e.CookbookInvitationId).HasName("PK__cookbook__81747E7AFD971F42");

            entity.ToTable("cookbook_invitation");

            entity.Property(e => e.CookbookInvitationId).HasColumnName("cookbook_invitation_id");
            entity.Property(e => e.CookbookId).HasColumnName("cookbook_id");
            entity.Property(e => e.CookbookInvitationDate)
                .HasColumnType("datetime")
                .HasColumnName("cookbook_invitation_date");
            entity.Property(e => e.CookbookInvitationStatus)
                .HasMaxLength(50)
                .HasColumnName("cookbook_invitation_status");
            entity.Property(e => e.RecipientPersonId).HasColumnName("recipient_person_id");
            entity.Property(e => e.ResponseDate)
                .HasColumnType("datetime")
                .HasColumnName("response_date");
            entity.Property(e => e.SenderPersonId).HasColumnName("sender_person_id");

            entity.HasOne(d => d.Cookbook).WithMany(p => p.CookbookInvitations)
                .HasForeignKey(d => d.CookbookId)
                .HasConstraintName("FK__cookbook___cookb__236943A5");

            entity.HasOne(d => d.RecipientPerson).WithMany(p => p.CookbookInvitationRecipientPeople)
                .HasForeignKey(d => d.RecipientPersonId)
                .HasConstraintName("FK__cookbook___recip__22751F6C");

            entity.HasOne(d => d.SenderPerson).WithMany(p => p.CookbookInvitationSenderPeople)
                .HasForeignKey(d => d.SenderPersonId)
                .HasConstraintName("FK__cookbook___sende__2180FB33");
        });

        modelBuilder.Entity<CookbookMember>(entity =>
        {
            entity.HasKey(e => e.CookbookMemberId).HasName("PK__cookbook__200A9AB81CC7E240");

            entity.ToTable("cookbook_member");

            entity.Property(e => e.CookbookMemberId).HasColumnName("cookbook_member_id");
            entity.Property(e => e.AddRecipePermission).HasColumnName("add_recipe_permission");
            entity.Property(e => e.CookbookId).HasColumnName("cookbook_id");
            entity.Property(e => e.DeleteRecipePermission).HasColumnName("delete_recipe_permission");
            entity.Property(e => e.InvitePermission).HasColumnName("invite_permission");
            entity.Property(e => e.JoinDate)
                .HasColumnType("datetime")
                .HasColumnName("join_date");
            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.HasOne(d => d.Cookbook).WithMany(p => p.CookbookMembers)
                .HasForeignKey(d => d.CookbookId)
                .HasConstraintName("FK__cookbook___cookb__1EA48E88");

            entity.HasOne(d => d.Person).WithMany(p => p.CookbookMembers)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__cookbook___perso__1DB06A4F");
        });

        modelBuilder.Entity<CookbookNotification>(entity =>
        {
            entity.HasKey(e => e.CookbookNotificationId).HasName("PK__cookbook__9BE745F7A926B36B");

            entity.ToTable("cookbook_notification");

            entity.Property(e => e.CookbookNotificationId).HasColumnName("cookbook_notification_id");
            entity.Property(e => e.ActionType)
                .HasMaxLength(255)
                .HasColumnName("action_type");
            entity.Property(e => e.CookbookId).HasColumnName("cookbook_id");
            entity.Property(e => e.IsSeen).HasColumnName("is_seen");
            entity.Property(e => e.NotificationDate)
                .HasColumnType("datetime")
                .HasColumnName("notification_date");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.SenderPersonId).HasColumnName("sender_person_id");

            entity.HasOne(d => d.Cookbook).WithMany(p => p.CookbookNotifications)
                .HasForeignKey(d => d.CookbookId)
                .HasConstraintName("FK__cookbook___cookb__32AB8735");

            entity.HasOne(d => d.Recipe).WithMany(p => p.CookbookNotifications)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__cookbook___recip__339FAB6E");

            entity.HasOne(d => d.SenderPerson).WithMany(p => p.CookbookNotifications)
                .HasForeignKey(d => d.SenderPersonId)
                .HasConstraintName("FK__cookbook___sende__31B762FC");
        });

        modelBuilder.Entity<IngredientCategory>(entity =>
        {
            entity.HasKey(e => e.IngredientCategoryId).HasName("PK__ingredie__82336D5EFE8AFD92");

            entity.ToTable("ingredient_category");

            entity.Property(e => e.IngredientCategoryId).HasColumnName("ingredient_category_id");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Recipe).WithMany(p => p.IngredientCategories)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__ingredien__recip__40058253");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__person__543848DF2E5C8BF0");

            entity.ToTable("person");

            entity.HasIndex(e => e.Email, "UQ__person__AB6E616406082C85").IsUnique();

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(255)
                .HasColumnName("display_name");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .HasColumnName("image_path");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.PasswordSalt)
                .HasMaxLength(255)
                .HasColumnName("password_salt");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("PK__recipe__3571ED9BBFB0B74A");

            entity.ToTable("recipe");

            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.CookbookId).HasColumnName("cookbook_id");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .HasColumnName("image_path");
            entity.Property(e => e.Summary).HasColumnName("summary");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Cookbook).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.CookbookId)
                .HasConstraintName("FK__recipe__cookbook__2645B050");
        });

        modelBuilder.Entity<RecipeComment>(entity =>
        {
            entity.HasKey(e => e.RecipeCommentId).HasName("PK__recipe_c__A92B9316A194FC6F");

            entity.ToTable("recipe_comment");

            entity.Property(e => e.RecipeCommentId).HasColumnName("recipe_comment_id");
            entity.Property(e => e.CommentText).HasColumnName("comment_text");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("creation_date");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

            entity.HasOne(d => d.Person).WithMany(p => p.RecipeComments)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__recipe_co__perso__3864608B");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeComments)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__recipe_co__recip__37703C52");
        });

        modelBuilder.Entity<RecipeDirection>(entity =>
        {
            entity.HasKey(e => e.RecipeDirectionId).HasName("PK__recipe_d__8FD06FCA50E7F9EF");

            entity.ToTable("recipe_direction");

            entity.Property(e => e.RecipeDirectionId).HasColumnName("recipe_direction_id");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .HasColumnName("image_path");
            entity.Property(e => e.Instruction)
                .HasMaxLength(255)
                .HasColumnName("instruction");
            entity.Property(e => e.Ordinal).HasColumnName("ordinal");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeDirections)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__recipe_di__recip__2EDAF651");
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasKey(e => e.RecipeIngredientId).HasName("PK__recipe_i__6DEC454CADD7AAC3");

            entity.ToTable("recipe_ingredient");

            entity.Property(e => e.RecipeIngredientId).HasColumnName("recipe_ingredient_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.IngredientName)
                .HasMaxLength(255)
                .HasColumnName("ingredient_name");
            entity.Property(e => e.Optional).HasColumnName("optional");
            entity.Property(e => e.Ordinal).HasColumnName("ordinal");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__recipe_in__recip__2BFE89A6");
        });

        modelBuilder.Entity<RecipeRating>(entity =>
        {
            entity.HasKey(e => e.RecipeRatingId).HasName("PK__recipe_r__D74DBC79BA6338FE");

            entity.ToTable("recipe_rating");

            entity.Property(e => e.RecipeRatingId).HasColumnName("recipe_rating_id");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("creation_date");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.RatingValue).HasColumnName("rating_value");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

            entity.HasOne(d => d.Person).WithMany(p => p.RecipeRatings)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__recipe_ra__perso__3C34F16F");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeRatings)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__recipe_ra__recip__3B40CD36");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
