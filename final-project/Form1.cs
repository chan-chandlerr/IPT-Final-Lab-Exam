// final-project/Form1.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq; // <--- ADD THIS LINE
using System.Windows.Forms;

namespace final_project
{
    public partial class Form1 : Form
    {
        private ClassroomChampion player1;
        private ClassroomChampion player2;
        private ClassroomChampion currentPlayer;
        private bool isPlayer1Turn = true;

        private Dictionary<string, Type> characterTypes = new Dictionary<string, Type>();

        private Color originalP1ForeColor;
        private Color originalP2ForeColor;
        private Font originalP1Font;
        private Font originalP2Font;

        private Brush hitBrush = Brushes.Yellow;
        private bool player1IsHit = false;
        private bool player2IsHit = false;

        private Rectangle player1Rect = new Rectangle(50, 160, 80, 80);
        private Rectangle player2Rect = new Rectangle(470, 40, 80, 80);


        public Form1()
        {
            InitializeComponent();
            PopulateCharacterTypes();

            if (lblP1NameDisplay != null) { originalP1ForeColor = lblP1NameDisplay.ForeColor; originalP1Font = lblP1NameDisplay.Font; }
            if (lblP2NameDisplay != null) { originalP2ForeColor = lblP2NameDisplay.ForeColor; originalP2Font = lblP2NameDisplay.Font; }

            ToggleAttackUI(false);

            if (pnlBattleScene != null) { pnlBattleScene.Invalidate(); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (characterTypes.Count == 0) PopulateCharacterTypes();

            foreach (var charName in characterTypes.Keys)
            {
                if (cmbPlayer1Char != null) cmbPlayer1Char.Items.Add(charName);
                if (cmbPlayer2Char != null) cmbPlayer2Char.Items.Add(charName);
            }
            if (cmbPlayer1Char != null && cmbPlayer1Char.Items.Count > 0) cmbPlayer1Char.SelectedIndex = 0;
            if (cmbPlayer2Char != null && cmbPlayer2Char.Items.Count > 0) cmbPlayer2Char.SelectedIndex = Math.Min(1, cmbPlayer2Char.Items.Count - 1);

            ResetUIAndGame();
        }

        private void PopulateCharacterTypes()
        {
            characterTypes.Clear();
            characterTypes.Add("Luffy the Quiz Whiz", typeof(LuffyTheQuizWhiz));
            characterTypes.Add("Zoro the Sharpener", typeof(ZoroTheSharpener));
            characterTypes.Add("Nami the Navigator", typeof(NamiTheNavigator));
            characterTypes.Add("Usopp the Sniper", typeof(UsoppTheSniper));
            characterTypes.Add("Sanji the Cook", typeof(SanjiTheCook));
            // TODO: Add Chopper, Robin, Franky, Brook, Jinbe
            // Example: characterTypes.Add("Chopper the Doctor", typeof(ChopperTheDoctor));
        }

        private void ResetUIAndGame()
        {
            if (lstBattleLog != null) lstBattleLog.Items.Clear();
            if (lblWinner != null) { lblWinner.Text = "Winner: "; lblWinner.ForeColor = Color.DarkGreen; }

            if (txtPlayer1Name != null && lblP1NameDisplay != null) lblP1NameDisplay.Text = txtPlayer1Name.Text;
            else if (lblP1NameDisplay != null) lblP1NameDisplay.Text = "Player 1";

            if (txtPlayer2Name != null && lblP2NameDisplay != null) lblP2NameDisplay.Text = txtPlayer2Name.Text;
            else if (lblP2NameDisplay != null) lblP2NameDisplay.Text = "Player 2";

            if (lblPlayer1Health != null) { lblPlayer1Health.Text = ""; lblPlayer1Health.Visible = false; }
            if (lblPlayer2Health != null) { lblPlayer2Health.Text = ""; lblPlayer2Health.Visible = false; }
            if (pbPlayer1Health != null) { pbPlayer1Health.Value = 0; pbPlayer1Health.Visible = false; }
            if (pbPlayer2Health != null) { pbPlayer2Health.Value = 0; pbPlayer2Health.Visible = false; }

            player1 = null;
            player2 = null;
            currentPlayer = null;

            if (btnStartBattle != null) { btnStartBattle.Text = "Start Battle!"; btnStartBattle.Enabled = true; }
            EnableSetupControls(true);
            UpdateTurnIndicatorVisuals(true);
            ToggleAttackUI(false);
            if (lblAttackDescription != null) lblAttackDescription.Text = "Attack Details Appear Here...";
            if (listBox1 != null) listBox1.Items.Clear();

            player1IsHit = false;
            player2IsHit = false;
            if (pnlBattleScene != null) pnlBattleScene.Invalidate();
        }

        private void EnableSetupControls(bool enabled)
        {
            if (txtPlayer1Name != null) txtPlayer1Name.Enabled = enabled;
            if (cmbPlayer1Char != null) cmbPlayer1Char.Enabled = enabled;
            if (txtPlayer2Name != null) txtPlayer2Name.Enabled = enabled;
            if (cmbPlayer2Char != null) cmbPlayer2Char.Enabled = enabled;
        }

        private void ToggleAttackUI(bool show)
        {
            if (listBox1 != null) listBox1.Visible = show;
            if (lblAttackDescription != null) lblAttackDescription.Visible = show;
            if (btnExecuteAttack != null) btnExecuteAttack.Visible = show;
        }

        private void btnStartBattle_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnStartBattle.Text == "Start Battle!" || btnStartBattle.Text == "Start New Battle")
                {
                    if (string.IsNullOrWhiteSpace(txtPlayer1Name.Text) || string.IsNullOrWhiteSpace(txtPlayer2Name.Text) ||
                        cmbPlayer1Char.SelectedItem == null || cmbPlayer2Char.SelectedItem == null)
                    { MessageBox.Show("Please fill in player names and select characters.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                    ResetUIAndGame();
                    lstBattleLog.Items.Clear();
                    lblWinner.Text = "Winner: ";

                    Type p1Type = characterTypes[cmbPlayer1Char.SelectedItem.ToString()];
                    player1 = (ClassroomChampion)Activator.CreateInstance(p1Type, txtPlayer1Name.Text);

                    Type p2Type = characterTypes[cmbPlayer2Char.SelectedItem.ToString()];
                    player2 = (ClassroomChampion)Activator.CreateInstance(p2Type, txtPlayer2Name.Text);

                    if (lblP1NameDisplay != null) lblP1NameDisplay.Text = player1.Name;
                    if (lblP2NameDisplay != null) lblP2NameDisplay.Text = player2.Name;

                    AddToBattleLog($"Battle Started: {player1.Name} vs {player2.Name}!", Color.Indigo, true);
                    AddToBattleLog("--------------------------------------------------", Color.DimGray);
                    EnableSetupControls(false);

                    isPlayer1Turn = true;
                    currentPlayer = player1;
                    btnStartBattle.Text = $"Prepare {GetDisplayName(currentPlayer)}'s Turn";
                    UpdateTurnIndicatorVisuals();
                    ToggleAttackUI(false);
                    if (pnlBattleScene != null) pnlBattleScene.Invalidate();
                }
                else if (btnStartBattle.Text.StartsWith("Prepare"))
                {
                    string turnStartMessage = currentPlayer.HandleTurnStartStatusEffects(currentPlayer == player1 ? player2 : player1);
                    if (!string.IsNullOrEmpty(turnStartMessage.Trim()))
                    {
                        AddToBattleLog(turnStartMessage, Color.MediumVioletRed);
                        if (pnlBattleScene != null) pnlBattleScene.Invalidate();
                    }

                    if (DeclareWinner())
                    {
                        EndBattle();
                        return;
                    }
                    LoadAttackChoicesForCurrentPlayer();
                    btnStartBattle.Enabled = false;
                    ToggleAttackUI(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetUIAndGame();
            }
        }

        private string GetDisplayName(ClassroomChampion champion)
        {
            if (champion == null) return "Unknown";
            return champion.Name.Contains(" (") ? champion.Name.Substring(0, champion.Name.IndexOf(" (")) : champion.Name;
        }

        private void LoadAttackChoicesForCurrentPlayer()
        {
            if (currentPlayer == null || listBox1 == null) return;
            AddToBattleLog($"{GetDisplayName(currentPlayer)}, choose your attack!", Color.Teal, true);

            listBox1.Items.Clear();
            if (lblAttackDescription != null) lblAttackDescription.Text = "Select an attack to see details.";

            if (currentPlayer.Moves != null)
            {
                foreach (var move in currentPlayer.Moves) { listBox1.Items.Add(move); }
            }
            if (listBox1.Items.Count > 0) { listBox1.SelectedIndex = 0; }
            if (btnExecuteAttack != null) btnExecuteAttack.Enabled = listBox1.SelectedItem != null;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is AttackMove selectedMove)
            {
                if (lblAttackDescription != null) lblAttackDescription.Text = selectedMove.GetFullDescription();
                if (btnExecuteAttack != null) btnExecuteAttack.Enabled = true;
            }
            else
            {
                if (lblAttackDescription != null) lblAttackDescription.Text = "Select an attack to see details.";
                if (btnExecuteAttack != null) btnExecuteAttack.Enabled = false;
            }
        }

        private void btnExecuteAttack_Click(object sender, EventArgs e)
        {
            if (currentPlayer == null || (player1.IsDefeated() || player2.IsDefeated()))
            {
                DeclareWinner(); EndBattle(); return;
            }

            if (listBox1.SelectedItem is AttackMove chosenMove)
            {
                ClassroomChampion attacker = currentPlayer;
                ClassroomChampion defender = (currentPlayer == player1) ? player2 : player1;
                int defenderOldHealth = defender.Health;

                string attackLog = attacker.ExecuteChosenAttack(defender, chosenMove);

                AddToBattleLog(attackLog);

                bool wasDamagingHit = defender.Health < defenderOldHealth;
                bool wasSuccessfulNonDamagingHit = (chosenMove.MinDamage == 0 && chosenMove.MaxDamage == 0 && !attackLog.Contains("misses!") && !attackLog.Contains("nothing...") && !attackLog.Contains("hesitating"));

                if (wasDamagingHit || wasSuccessfulNonDamagingHit)
                {
                    if (defender == player1 && attacker != player1) player1IsHit = true;
                    else if (defender == player2 && attacker != player2) player2IsHit = true;

                    if ((defender == player1 && attacker != player1) || (defender == player2 && attacker != player2))
                    {
                        if (hitEffectTimer != null) hitEffectTimer.Start();
                    }
                }

                attacker.TickDownStatusEffects();
                if (pnlBattleScene != null) pnlBattleScene.Invalidate();

                ToggleAttackUI(false);

                if (DeclareWinner())
                {
                    EndBattle();
                }
                else
                {
                    isPlayer1Turn = !isPlayer1Turn;
                    currentPlayer = isPlayer1Turn ? player1 : player2;
                    UpdateTurnIndicatorVisuals();
                    if (btnStartBattle != null) { btnStartBattle.Text = $"Prepare {GetDisplayName(currentPlayer)}'s Turn"; btnStartBattle.Enabled = true; }
                }
            }
            else
            {
                MessageBox.Show("Please select an attack first!", "No Attack Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateHealthDisplays()
        {
            if (pnlBattleScene != null) pnlBattleScene.Invalidate();
        }

        private void AddToBattleLog(string message) { AddToBattleLog(message, Color.Black); }
        private void AddToBattleLog(string message, Color color, bool bold = false)
        {
            string prefix = "";
            if (message.Contains("CRITICAL HIT!") || message.Contains("Massive Impact!") || message.Contains("Finishing Blow!") || message.Contains("Overwhelming Pressure!")) prefix = "💥 ";
            else if (message.Contains("deals damage") || message.Contains("takes damage")) prefix = "⚔️ ";
            else if (message.Contains("has been defeated") || message.Contains("victorious")) prefix = "🏆 ";
            else if (message.Contains("choose your attack") || message.Contains("prepares for battle")) prefix = "👉 ";
            else if (message.ToLower().Contains("poison!") || message.ToLower().Contains("weakened!") || message.ToLower().Contains("elusive!") || message.ToLower().Contains("fell!") || message.ToLower().Contains("rose!") || message.ToLower().Contains("recovers hp!") || message.ToLower().Contains("affected by")) prefix = "✨ ";

            if (lstBattleLog != null)
            {
                string[] lines = message.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        lstBattleLog.Items.Add(prefix + line.Trim());
                    }
                }
                if (lstBattleLog.Items.Count > 0) { lstBattleLog.SelectedIndex = lstBattleLog.Items.Count - 1; lstBattleLog.ClearSelected(); }
            }
        }

        private bool DeclareWinner()
        {
            if (player1 == null || player2 == null) return false;
            bool winnerDeclared = false;
            Color winnerTextColor = Color.DarkGreen; // Corrected Type

            if (player1.IsDefeated())
            {
                if (player2 != null) winnerTextColor = (player2.CharacterBrush as SolidBrush)?.Color ?? Color.Blue; // Corrected variable
                if (lblWinner != null) { lblWinner.Text = $"Winner: {player2.Name}!"; lblWinner.ForeColor = winnerTextColor; } // Corrected variable
                AddToBattleLog($"{player2.Name} is victorious!", Color.Gold, true);
                winnerDeclared = true;
            }
            else if (player2.IsDefeated())
            {
                if (player1 != null) winnerTextColor = (player1.CharacterBrush as SolidBrush)?.Color ?? Color.Red; // Corrected variable
                if (lblWinner != null) { lblWinner.Text = $"Winner: {player1.Name}!"; lblWinner.ForeColor = winnerTextColor; } // Corrected variable
                AddToBattleLog($"{player1.Name} is victorious!", Color.Gold, true);
                winnerDeclared = true;
            }
            if (winnerDeclared && pnlBattleScene != null) pnlBattleScene.Invalidate();
            return winnerDeclared;
        }

        private void EndBattle()
        {
            if (btnStartBattle != null) { btnStartBattle.Text = "Start New Battle"; btnStartBattle.Enabled = true; }
            EnableSetupControls(true);
            UpdateTurnIndicatorVisuals(true);
            ToggleAttackUI(false);
            if (hitEffectTimer != null && hitEffectTimer.Enabled) hitEffectTimer.Stop();
            player1IsHit = false;
            player2IsHit = false;
            if (pnlBattleScene != null) pnlBattleScene.Invalidate();
        }

        private void UpdateTurnIndicatorVisuals(bool reset = false)
        {
            if (lblP1NameDisplay == null || lblP2NameDisplay == null) return;
            Font p1FontToUse = originalP1Font ?? lblP1NameDisplay.Font;
            Font p2FontToUse = originalP2Font ?? lblP2NameDisplay.Font;
            Color p1Color = originalP1ForeColor;
            Color p2Color = originalP2ForeColor;

            if (!reset)
            {
                p1Color = isPlayer1Turn ? (player1?.CharacterBrush as SolidBrush)?.Color ?? Color.Navy : Color.DimGray;
                p2Color = !isPlayer1Turn ? (player2?.CharacterBrush as SolidBrush)?.Color ?? Color.DarkRed : Color.DimGray;

                if (isPlayer1Turn && player1 != null && p1Color.GetBrightness() < 0.3f) p1Color = ControlPaint.Light(p1Color, 0.6f);
                else if (isPlayer1Turn && player1 != null && p1Color.GetBrightness() > 0.7f) p1Color = ControlPaint.Dark(p1Color, 0.3f);

                if (!isPlayer1Turn && player2 != null && p2Color.GetBrightness() < 0.3f) p2Color = ControlPaint.Light(p2Color, 0.6f);
                else if (!isPlayer1Turn && player2 != null && p2Color.GetBrightness() > 0.7f) p2Color = ControlPaint.Dark(p2Color, 0.3f);

            }
            else
            {
                if (p1Color == SystemColors.ControlText || p1Color == SystemColors.Control || p1Color == null) p1Color = Color.Black;
                if (p2Color == SystemColors.ControlText || p2Color == SystemColors.Control || p2Color == null) p2Color = Color.Black;
            }

            lblP1NameDisplay.ForeColor = p1Color;
            lblP1NameDisplay.Font = new Font(p1FontToUse, (reset || !isPlayer1Turn) ? FontStyle.Regular : FontStyle.Bold);
            lblP2NameDisplay.ForeColor = p2Color;
            lblP2NameDisplay.Font = new Font(p2FontToUse, (reset || isPlayer1Turn) ? FontStyle.Regular : FontStyle.Bold);
        }

        private void pnlBattleScene_Paint(object sender, PaintEventArgs e)
        {
            if (pnlBattleScene == null) return;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var bgBrush = new LinearGradientBrush(pnlBattleScene.ClientRectangle, Color.FromArgb(135, 206, 250), Color.FromArgb(34, 139, 34), 90F))
            { g.FillRectangle(bgBrush, pnlBattleScene.ClientRectangle); }

            RectangleF groundRectP1 = new RectangleF(player1Rect.X - 15, player1Rect.Bottom - 15, player1Rect.Width + 30, 25);
            using (var groundBrushP1 = new SolidBrush(Color.FromArgb(100, 160, 120, 40)))
                g.FillEllipse(groundBrushP1, groundRectP1);

            RectangleF groundRectP2 = new RectangleF(player2Rect.X - 15, player2Rect.Bottom - 15, player2Rect.Width + 30, 25);
            using (var groundBrushP2 = new SolidBrush(Color.FromArgb(100, 160, 120, 40)))
                g.FillEllipse(groundBrushP2, groundRectP2);

            if (player1 != null)
            {
                DrawCharacterShape(g, player1, player1Rect, player1IsHit);
                DrawHealthBar(g, player1, new Rectangle(player1Rect.X - 10, player1Rect.Y - 28, 100, 18), false);
                DrawStatusIcons(g, player1, new Point(player1Rect.Left, player1Rect.Y - 28 - 18 - 2));
            }

            if (player2 != null)
            {
                DrawCharacterShape(g, player2, player2Rect, player2IsHit);
                DrawHealthBar(g, player2, new Rectangle(player2Rect.X - 10, player2Rect.Y - 28, 100, 18), true);
                DrawStatusIcons(g, player2, new Point(player2Rect.Left, player2Rect.Y - 28 - 18 - 2));
            }
        }

        private void DrawCharacterShape(Graphics g, ClassroomChampion character, Rectangle bounds, bool isHit)
        {
            Brush currentBrush = isHit ? hitBrush : character.CharacterBrush;
            using (var outlinePen = new Pen(Color.FromArgb(180, Color.Black), 2.5f))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (var shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
                {
                    g.FillEllipse(shadowBrush, bounds.X + 5, bounds.Bottom - 10, bounds.Width - 10, 15);
                }

                switch (character.CharacterShape)
                {
                    case ShapeType.Circle: g.FillEllipse(currentBrush, bounds); g.DrawEllipse(outlinePen, bounds); break;
                    case ShapeType.Square: g.FillRectangle(currentBrush, bounds); g.DrawRectangle(outlinePen, bounds); break;
                    case ShapeType.Triangle:
                        Point[] trianglePoints = { new Point(bounds.X + bounds.Width / 2, bounds.Y), new Point(bounds.Right, bounds.Bottom), new Point(bounds.Left, bounds.Bottom) };
                        g.FillPolygon(currentBrush, trianglePoints); g.DrawPolygon(outlinePen, trianglePoints); break;
                    case ShapeType.Star:
                        PointF[] starPoints = new PointF[10]; float oR = bounds.Width / 2f, iR = oR / 2.5f; PointF c = new PointF(bounds.X + oR, bounds.Y + oR);
                        float angle = -90 * (float)(Math.PI / 180); for (int i = 0; i < 10; i++) { float r = (i % 2 == 0) ? oR : iR; starPoints[i] = new PointF(c.X + r * (float)Math.Cos(angle), c.Y + r * (float)Math.Sin(angle)); angle += 36 * (float)(Math.PI / 180); }
                        g.FillPolygon(currentBrush, starPoints); g.DrawPolygon(outlinePen, starPoints); break;
                    case ShapeType.Hexagon:
                        PointF[] hexPoints = new PointF[6]; float hR = bounds.Width / 2f; PointF hC = new PointF(bounds.X + hR, bounds.Y + hR);
                        for (int i = 0; i < 6; i++) { hexPoints[i] = new PointF(hC.X + hR * (float)Math.Cos(i * 60 * Math.PI / 180f), hC.Y + hR * (float)Math.Sin(i * 60 * Math.PI / 180f)); }
                        g.FillPolygon(currentBrush, hexPoints); g.DrawPolygon(outlinePen, hexPoints); break;
                    case ShapeType.RoundedRectangle:
                        using (GraphicsPath path = new GraphicsPath())
                        {
                            int cornerRadius = Math.Min(bounds.Width, bounds.Height) / 3;
                            path.AddArc(bounds.X, bounds.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
                            path.AddArc(bounds.Right - cornerRadius * 2, bounds.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
                            path.AddArc(bounds.Right - cornerRadius * 2, bounds.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
                            path.AddArc(bounds.X, bounds.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
                            path.CloseFigure();
                            g.FillPath(currentBrush, path); g.DrawPath(outlinePen, path);
                        }
                        break;
                }
            }
        }

        private void DrawHealthBar(Graphics g, ClassroomChampion character, Rectangle bounds, bool isOpponentBar)
        {
            g.FillRectangle(Brushes.Black, bounds.X - 1, bounds.Y - 1, bounds.Width + 2, bounds.Height + 2);
            g.FillRectangle(Brushes.WhiteSmoke, bounds);

            float healthPercent = Math.Max(0, (float)character.Health / character.MaxHealth);
            Brush healthFillBrush = Brushes.LimeGreen;
            if (healthPercent < 0.5f) healthFillBrush = Brushes.Gold;
            if (healthPercent < 0.2f) healthFillBrush = Brushes.OrangeRed;

            Rectangle hpLabelRect = new Rectangle(bounds.X + 1, bounds.Y + 1, 22, bounds.Height - 2);
            g.FillRectangle(Brushes.DarkSlateGray, hpLabelRect);
            using (Font hpFont = new Font("Consolas", 7f, FontStyle.Bold))
            {
                TextRenderer.DrawText(g, "HP", hpFont, hpLabelRect, Color.White, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }

            Rectangle actualHealthFillRect = new Rectangle(bounds.X + 1 + hpLabelRect.Width, bounds.Y + 1, (int)((bounds.Width - 2 - hpLabelRect.Width) * healthPercent), bounds.Height - 2);
            g.FillRectangle(healthFillBrush, actualHealthFillRect);

            string nameText = GetDisplayName(character);
            using (Font nameFont = new Font("Verdana", 7.5f, FontStyle.Bold))
            {
                Color nameColor = Color.FromArgb(240, 240, 240);
                TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.NoPadding;
                Point namePos = new Point(bounds.Left, bounds.Top - (int)g.MeasureString(nameText, nameFont).Height - 1);
                SizeF nameSize = g.MeasureString(nameText, nameFont);
                g.FillRectangle(new SolidBrush(Color.FromArgb(100, 0, 0, 0)), namePos.X - 2, namePos.Y - 1, nameSize.Width + 4, nameSize.Height + 2);
                TextRenderer.DrawText(g, nameText, nameFont, namePos, nameColor, flags);
            }
        }

        private void DrawStatusIcons(Graphics g, ClassroomChampion character, Point startLocation)
        {
            if (character.ActiveStatusEffects.Count == 0) return;
            int iconSize = 15; int spacing = 2; int currentX = startLocation.X;
            Font iconFont = new Font("Arial Narrow", 6.5f, FontStyle.Bold);
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            int yPos = startLocation.Y;

            foreach (var effectEntry in character.ActiveStatusEffects.OrderBy(kv => kv.Key.ToString()).ToList())
            {
                StatusEffect effect = effectEntry.Key;
                Rectangle iconRect = new Rectangle(currentX, yPos, iconSize, iconSize);
                Brush bgBrush = Brushes.Transparent; string Abr = ""; Color txtColor = Color.White;

                switch (effect)
                {
                    case StatusEffect.Poisoned: bgBrush = new SolidBrush(Color.FromArgb(200, 102, 0, 102)); Abr = "PSN"; txtColor = Color.White; break;
                    case StatusEffect.AttackUp: bgBrush = new SolidBrush(Color.FromArgb(200, 255, 100, 0)); Abr = "ATK↑"; txtColor = Color.Black; break;
                    case StatusEffect.DefenseUp: bgBrush = new SolidBrush(Color.FromArgb(200, 0, 102, 204)); Abr = "DEF↑"; txtColor = Color.White; break;
                    case StatusEffect.AttackDown: bgBrush = new SolidBrush(Color.FromArgb(200, 88, 88, 88)); Abr = "ATK↓"; txtColor = Color.LightGray; break;
                    case StatusEffect.DefenseDown: bgBrush = new SolidBrush(Color.FromArgb(200, 150, 150, 150)); Abr = "DEF↓"; txtColor = Color.Black; break;
                    case StatusEffect.AccuracyDown: bgBrush = new SolidBrush(Color.FromArgb(200, 139, 69, 19)); Abr = "ACC↓"; txtColor = Color.White; break;
                    case StatusEffect.EvasionUp: bgBrush = new SolidBrush(Color.FromArgb(200, 60, 179, 113)); Abr = "EVA↑"; txtColor = Color.Black; break;
                }
                if (!string.IsNullOrEmpty(Abr))
                {
                    g.FillEllipse(bgBrush, iconRect);
                    TextRenderer.DrawText(g, Abr, iconFont, iconRect, txtColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
                    currentX += iconSize + spacing;
                    if (bgBrush != Brushes.Transparent) bgBrush.Dispose();
                }
            }
            iconFont.Dispose(); sf.Dispose();
        }

        private void hitEffectTimer_Tick(object sender, EventArgs e)
        {
            player1IsHit = false; player2IsHit = false;
            if (hitEffectTimer != null) hitEffectTimer.Stop();
            if (pnlBattleScene != null) pnlBattleScene.Invalidate();
        }

        // --- Event Handlers for controls that might exist in your designer ---
        private void cmbPlayer1Char_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblPlayer2Health_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void lblP1NameDisplay_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
    }
}