# Review refusals

Every ChatGPT suggestion refused, with the reason. Format: key or text, proposal, reason, date.

## 2026-11-12 (review-translation, TRANSLATION_REVIEW.md page 1 of 1, revision 40690e7)

| Key or text | Proposal | Reason |
|---|---|---|
| Provenance of the Defs `Original` column (Chinese in the Original column) | document or rewrite | Already stated in the review header; nothing to rewrite. |
| French keys with empty Original and English (`SZ_ChelaBlunt.*`, `SZ_Firecracker_Flame*.*`, `deathMessage`, `SZ_Clone_*.jobString`, `SZ_QQPawnFlyingStrike.label`) | document as inherited or exclude from the generator | Generator output, no mod text to change; the French values are ours and stay. |
| `ChineseSimplified` `SZ_Clone_MingShe`, `SZ_Clone_QiongQi`, `SZ_Clone_YearBeast` `.description` | restore the corpse cloning mechanism | The Chinese already says it (DNA taken from the corpse, copied, culture medium, device, clone for the colony); nothing omitted. Only the two sexie forms were distinguished (applied). |

Applied the same day: French `pied` to `patte` for the four paw labels of `SZ_QuadrupedAnimalWithPawsTailWings`; the 22 missing `ChineseSimplified` keys filled (Keyed and DefInjected); after the Audit rule of the same day (source column corrected whatever the licence), the `ChineseSimplified` corrections of `SZ_MingShe`, `SZ_SeXie`, `SZ_Chicken`, `SZ_Strength`, `SZ_Clone_SeXieA` and `SZ_Clone_SeXieB` (human form, scorpion form), `SZ_BeastGeneExtractor` and `SZ_YearBeast_Friendly` (PawnKindDef label).

## 2026-11-12, second pass (same revision line, after the first corrections)

Nothing refused. Applied: `ChineseSimplified` `SZ_Insect_SeXie` left and right elytra `左鞘翅` / `右鞘翅`; `ChineseBeast_Gun_Dragon.tools.handle.label` `握把` (handle, as the English and French "poignée").

## 2026-11-12, third pass

Nothing refused. Applied: English `SZ_Storyteller_Sexie.description` "left on the rim" (Mod/Defs/StoryTeller/storyteller.xml; the upstream wording, local edit under the Audit rule of 2026-11-12); French `SZ_SeXie_Friendly.description` `griffes venimeuses` (human form; `SZ_SeXieInsect_Friendly` keeps `pinces`); Chinese `SZ_MingShe.description` colon before the wind shield clause and `SZ_YearBeast_Friendly.description` punctuation and `在面对`; duplicate `SZ_QQAnimation.label` and `.description` removed from `ChineseSimplified/DefInjected/ThingDef/CHSSPawn.xml` (same value twice, one kept).
