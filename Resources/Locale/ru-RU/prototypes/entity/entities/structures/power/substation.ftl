ent-BaseSubstation = подстанция
    .desc = Понижает напряжение подаваемого в него электричества.
    .suffix = { "" }

ent-BaseSubstationWall = настенная подстанция
    .desc = Подстанция, предназначенная для компактных шаттлов и помещений.
    .suffix = { "" }

ent-SubstationBasic = { ent-BaseSubstation }
    .desc = { ent-BaseSubstation.desc }
    .suffix = Базовая, 2,5МДж

ent-SubstationBasicEmpty = { ent-SubstationBasic }
    .desc = { ent-SubstationBasic.desc }
    .suffix = Пустой

ent-SubstationWallBasic = { ent-BaseSubstationWall }
    .desc = { ent-BaseSubstationWall.desc }
    .suffix = Базовая, 2МДж

ent-BaseSubstationWallFrame = каркас настенной подстанции
    .desc = Каркас для строительства подстанции.
    .suffix = { "" }
