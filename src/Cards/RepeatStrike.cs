using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Random;
using MegaCrit.Sts2.Core.ValueProps;
using ModSmith.Models;

namespace GamblingMod;

class RepeatStrike : ModSmithCardModel
{
  public RepeatStrike()
    : base(1, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
  {
  }

  protected override IEnumerable<DynamicVar> CanonicalVars => [
    new DamageVar(5m, ValueProp.Move),
  ];

  protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
  {
    ArgumentNullException.ThrowIfNull(cardPlay.Target, "cardPlay.Target");

    // roll first: each success adds a hit, the first failure stops
    int hits = 0;
    while (hits < 200 && (RunState?.Rng.Niche.NextBool() ?? Rng.Chaotic.NextBool()))
    {
      hits++;
    }

    GamblingModMain.Logger.Info($"RepeatStrike hits: {hits}");

    if (hits == 0) return;   // unlucky: no damage

    await DamageCmd.Attack(DynamicVars.Damage.BaseValue)
      .WithHitCount(hits)
      .FromCard(this, cardPlay)
      .Targeting(cardPlay.Target)
      .WithHitFx("vfx/vfx_attack_slash")
      .Execute(choiceContext);
  }
  protected override void OnUpgrade()
  {
    DynamicVars.Damage.UpgradeValueBy(3m);
  }
}