using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Animations;
using MonoGame.Extended.Animations.SpriteSheets;
using MonoGame.Extended.TextureAtlases;
using MonoGame.Extended.Sprites;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Illumination
{
    public class Player
    {
        private AnimatedSprite playerSprite;
        private bool walking = false;
        private short numMovementButtonsPressed = 0;

        public Vector2 Position { get; set; } = Vector2.Zero;

        public Vector2 MovementSpeed { get; set; } = new Vector2(5, 5);

        public Vector2 Scale { get; set; } = Vector2.One;

        public Player(Vector2 position = default(Vector2))
        {
            Position = position;

            var characterAtlas = new TextureAtlas("kunio", 
                AssetManager.GetTexture(ETexture.MAIN_CHARACTER), 
                AssetManager.GetFrameMap(EFrameMap.MAIN_CHARACTER));

            var characterAnimationFactory = new SpriteSheetAnimationFactory(characterAtlas);
            characterAnimationFactory.Add("idle", new SpriteSheetAnimationData(new[] { 0, 1, 2, 3, 4 }, isLooping: true));
            characterAnimationFactory.Add("walking", new SpriteSheetAnimationData(new[] { 5, 6 }, isLooping: true));

            playerSprite = new AnimatedSprite(characterAnimationFactory, "idle");
        }

        public void Update(GameTime gameTime)
        {
            playerSprite.Update(gameTime);
            UpdateControllingPlayer();
        }

        private void UpdateControllingPlayer()
        {
            if (InputManager.IsKeyPressed(Keys.W))
            {
                if (InputManager.OnKeyPressed(Keys.W))
                    ++numMovementButtonsPressed;
                Position = new Vector2(Position.X, Position.Y - MovementSpeed.Y);
            }
            else if (InputManager.OnKeyReleased(Keys.W))
            {
                --numMovementButtonsPressed;
            }

            if (InputManager.IsKeyPressed(Keys.A))
            {
                if (InputManager.OnKeyPressed(Keys.A))
                    ++numMovementButtonsPressed;
                Position = new Vector2(Position.X - MovementSpeed.X, Position.Y);
            }
            else if (InputManager.OnKeyReleased(Keys.A))
            {
                --numMovementButtonsPressed;
            }

            if (InputManager.IsKeyPressed(Keys.S))
            {
                if (InputManager.OnKeyPressed(Keys.S))
                    ++numMovementButtonsPressed;
                Position = new Vector2(Position.X, Position.Y + MovementSpeed.Y);
            }
            else if (InputManager.OnKeyReleased(Keys.S))
            {
                --numMovementButtonsPressed;
            }

            if (InputManager.IsKeyPressed(Keys.D))
            {
                if (InputManager.OnKeyPressed(Keys.D))
                    ++numMovementButtonsPressed;
                Position = new Vector2(Position.X + MovementSpeed.X, Position.Y);
            }
            else if (InputManager.OnKeyReleased(Keys.D))
            {
                --numMovementButtonsPressed;
            }

            if (numMovementButtonsPressed > 0)
                playerSprite.Play("walking");
            else
                playerSprite.Play("idle");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(playerSprite, Position, 0, Scale);
            spriteBatch.End();
        }
    }
}
