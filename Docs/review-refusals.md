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

## 2026-11-12, fourth pass

Nothing refused. Applied (5): Chinese clone recipe openings (`从…的尸体中…花些时间加入合适的培养液`, five recipes); `SZ_BeastGene.description` closing parenthesis; the two Original (Chinese) beast messages of `Mod/Defs/Incident/Beasts.xml` (`若放任其肆虐`, `为了让庄稼能够顺利生长`, local edit under the Audit rule of 2026-11-12, to go upstream with the rest); French `SZ_SeXie.description` last sentence (venom and pain).

## 2026-11-12, fifth pass

Applied (5): French `SZ_Chicken.description` quote (`Quel beau coq ! »`, no `tu`); French `SZ_SeXie.description` `contre ses compagnons` (English: against their own companions); Chinese `SZ_SeXieInsect_Friendly.description` names the scorpion form; Chinese `SZ_ExtractGene_QiongQiB.label` `提取穷奇-眼基因` (the gene is the eye, not compound eyes); English thought `SZ_ChickenCrow` stage "fighting spirit" and "clouds" (Mod/Defs/Thought/thoughts.xml, Audit rule of 2026-11-12, to go upstream).

Refused (7):

| Key or text | Proposal | Reason |
|---|---|---|
| `TRANSLATION_REVIEW.md` header revision `5bd5cad` against `40690e7` | regenerate from the audited revision | The header always carries the current commit; the review is regenerated after each pass, `40690e7` in the first log line is only the revision of the first pass. |
| French `ChineseBeast_Gun_egret.label` | keep « Egret » | A weapon name is translated (白鹭 is the egret); « Aigrette » is a choice of wording, left as is. |
| English `SZ_Storyteller_Sexie.description` "Awkward random events" | rewording | Taste; the upstream wording reads fine in context. |
| Chinese incident labels `SZ_YearBeastApproach.label`, `SZ_BeastApproach.label`, `SZ_BeastApproachTunnel.label` | drop the click hint | The hint is the original design (the same hint is in the letter labels); no truncation seen in the captures. |
| `PUBLICATION.md` adult content line | reorder words | Already grammatical. |
| `PUBLICATION.md` nian bullet | full sentence | A list item in a bullet list, fragment on purpose like its siblings. |

## 2026-11-12, sixth pass

Applied (2): Original (Chinese) message of `SZ_BeastApproach` beast 1 in `Mod/Defs/Incident/Beasts.xml` (word order and comma, to go upstream with the rest); `PUBLICATION.md` gallery note "with single-digit prefixes".

Refused (1): `CHANGELOG.md` `[Unreleased]`, wind barrier bullet, "in front of the list" to "in the list" and "following" to "subsequent": the projectile sat at the head of the list, which is the cause of the repeated error, so "in front of" is meant; "following tick" is plain English.

## 2026-11-12, eighth pass (the seventh failed: no credits)

Nothing refused. Applied (3): Chinese `SZ_Clone_MingShe.description` adds the drought (`同样会带来干旱`, wind flavour kept); Chinese `SZ_Firecracker.description` adds the tenth-damage rule; "original authors'" and "If any original author" in `PUBLICATION.md`, `Mod/About/About.xml` and `README.md` (four authors are credited).

## 2026-11-12, ninth pass

Nothing refused. Applied (2): Chinese `SZGene_QiongQi_Eyes.description` (attacks, not skills) and `SZGene_QiongQi_Scratch.description` (armour, armour penetration), both as the English.

## 2026-11-12, tenth pass

Nothing refused. Applied (2): Chinese `SZ_MingShe_WindWing.description` (anything inside the shield, objects from outside, as the English); Chinese `SZ_YearBeast.description` `巨响` for "loud noise".

## 2026-11-12, eleventh pass

Nothing refused. The proper-noun table asked for nothing (all forms deliberate). Applied (2): "she likes to cause trouble" for the fifth storyteller in `PUBLICATION.md` and `Mod/About/About.xml` (kept identical); `CHANGELOG.md` `[Unreleased]` wind barrier bullet, comma splices turned into semicolons.

## 2026-11-12, twelfth pass

The proper-noun table asked for nothing. Applied (3 groups): French `RecipeDef` descriptions in the infinitive (18 keys, `Prélever et copier`, `faire fonctionner`, `Extraire`, `Utiliser`); Chinese `ChineseBeast_Gun_egret.label` and `_Dragon.label` `反凶兽步枪` (rifle, as the English label); Chinese `SZGene_QiongQi_FlyingStrike` label and description `冲刺`, the word of the ability.

Refused (1): Chinese `SZ_MingSheDrought.letterText`, `持续` repeated: the repetition is the original's emphasis (the sun that keeps on), a matter of taste, kept.

## 2026-11-12, thirteenth pass

Nothing refused. The proper-noun table asked for nothing. Applied (2): Chinese `SZ_ExtractGene.jobString` `正在从凶兽中提取基因。` (as the English and French job string); Chinese gun descriptions `反凶兽步枪`, in line with the labels changed in the twelfth pass (descriptions only where the phrase `反凶兽突击步枪` stood).

## 2026-11-12, fourteenth pass

Applied (1): Chinese `SZ_QiongQi.description` `以…为原型` construction.

Kept as is (2 proper-noun questions, no change): `Shenzhou` as `华夏` in `SZ_QiongQi.description` while other texts use `神州` (the original Chinese uses both, `华夏` for the settlements, `神州` for the land; left as the original has it); `Longbow` as `长弓` in `SZ_Chicken.description` (the original author's nickname, an intended wink).

## 2026-11-12, fifteenth pass

Applied (1): "An update of andery233xj, ..." in `PUBLICATION.md` and `Mod/About/About.xml` (kept identical).

Refused (2):

| Key or text | Proposal | Reason |
|---|---|---|
| French `SZ_DebugCategory` | `Ancient Chinese Beast (Bêtes chinoises antiques)` | A label of the debug menu, shown to nobody who plays; no rule of `docs/TRANSLATIONS.md` asks for the English name beside the French one there. Left as is. |
| `Mod/About/About.xml` `<name>` and the Workshop title | add a French form | Changes the published title of the item; an owner decision, not a translation fix. |

The proper-noun "to decide" lists (creature names, Shenzhou, Longbow, Egret, Sexie title) repeat choices already kept in earlier passes; nothing changed.

## 2026-11-12, sixteenth pass

Applied (1): English `SZGene_QiongQi_Scratch.description` "Usually hit the head." (plural subject, `Mod/Defs/Gene/QiongQi.xml`, to go upstream with the rest).

Not applied (2), waiting for Virginie: the French form of the mod title (registry empty, Audit 2026-11-12); everything in the PROPER NOUNS section (decision table sent to her). The Chinese long descriptions: ChatGPT proposes nothing, nothing to apply.

## 2026-11-13, seventeenth pass

Applied (2): French `SZ_YearBeast_Friendly.label` in `PawnKindDef` and `ThingDef`: `Nian (amical)` (Nian is masculine, my agreement miss). The PROPER NOUNS TO DECIDE items (the upstream title and three third-party mod names) are sent to Virginie in the report and, for mod titles, to Audit with TITLE? first (rule 26).

## 2026-11-13, eighteenth pass

Applied (3): French `50 %`, `10 %` and `1 %` with the space before the percent sign (ThingDef, Keyed); English "Pleiades star officer" in lower case in `PUBLICATION.md` and `Mod/About/About.xml` (kept identical, as every other occurrence).

Not applied: the two PROPER NOUNS items (the Chinese title in a citation, "Use This Instead"), sent to Virginie.

## 2026-11-13, nineteenth pass

Applied (1): French `SZ_BeastApproach` beast 0: "une bête décrite seulement dans le Shanhaijing". Not applied: Longbow (the only PROPER NOUNS item, kept, sent to Virginie).

## 2026-11-13, twentieth pass

Applied (2): Chinese `SZ_YearBeastApproach.letterText` `出现在殖民地附近`; Chinese `SZ_Storyteller_Sexie.description` `色邪偏好变化不断的故事`.

Refused (1): Chinese `SZ_ChickenPasses.letterText` compaction (`加入殖民地`): the `我们` and the longer phrase are the fictional voice of the original, a matter of taste.

## 2026-11-13, twenty-first pass

PROPER NOUNS: nothing left to decide. Applied (3): French `SZ_Chicken` "son chant peut aussi être déclenché manuellement" (no implicit address); `SZ_SeXie` "parmi les colons" and "fait s'effondrer un colon" (the English names a colonist). `SZ_SeXieInsect` carries no such passage in the French (checked), nothing to change.

## 2026-11-13, twenty-second pass

PROPER NOUNS: nothing to decide. Applied (2): English "Breathes fire in a cone." (`SZ_YearBeast_Flamethrower`) and "can breathe fire in a cone" (`SZGene_YearBeast_Flamethrower`) in `Mod/Defs` (Audit rule of 2026-11-12, to go upstream with the rest).
