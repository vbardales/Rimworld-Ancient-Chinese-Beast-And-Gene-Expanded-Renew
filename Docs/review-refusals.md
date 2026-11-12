# Review refusals

Every ChatGPT suggestion refused, with the reason. Format: key or text, proposal, reason, date.

## 2026-11-12 (review-translation, TRANSLATION_REVIEW.md page 1 of 1, revision 40690e7)

| Key or text | Proposal | Reason |
|---|---|---|
| `ChineseSimplified` `SZ_MingShe.description` | `天兵基因工程项目` | Source column (the Chinese is the original text). Licence `silent`, upstream not tied to the credited authors: no local edit; upstream pull request MonsterTower/AncientChineseBeast#1 is the channel. |
| `ChineseSimplified` `SZ_SeXie.description` | `这会使…` | Same: source column, not edited locally. |
| `ChineseSimplified` `SZ_Chicken.description` | `该能力也可手动释放。` | Same. |
| `ChineseSimplified` `SZ_Strength.description` | `怪力。使携带者徒手攻击的伤害翻倍。` | Same. |
| `ChineseSimplified` `SZ_Clone_MingShe`, `SZ_Clone_QiongQi`, `SZ_Clone_SeXieA`, `SZ_Clone_SeXieB`, `SZ_Clone_YearBeast` `.description` | restore corpse cloning mechanism, name the two sexie forms | Same: original Chinese text, not edited locally. |
| `ChineseSimplified` `SZ_BeastGeneExtractor.description` | `殖民者只需保存…`, `宏大的规模` | Same. |
| `ChineseSimplified` `PawnKindDef/SZ_YearBeast_Friendly.label` | `年兽（友方）` | Same. |
| Provenance of Defs `Original` column (Chinese in the Original column) | document or rewrite | Already stated in the review header; no source rewrite (licence `silent`). |
| French keys with empty Original and English (`SZ_ChelaBlunt.*`, `SZ_Firecracker_Flame*.*`, `deathMessage`, `SZ_Clone_*.jobString`, `SZ_QQPawnFlyingStrike.label`) | document as inherited or exclude from the generator | Generator output, no mod text to change; the French values are ours and stay. |

Applied the same day: French `pied` to `patte` for the four paw labels of `SZ_QuadrupedAnimalWithPawsTailWings`; the 22 missing `ChineseSimplified` keys filled (Keyed and DefInjected).
