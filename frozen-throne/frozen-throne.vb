
declare global.number[0] with network priority local
declare global.number[1] with network priority local
declare global.number[2] with network priority local
declare global.number[3] with network priority local
declare global.number[4] with network priority low
declare global.number[5] with network priority low
declare global.number[6] with network priority low
declare global.number[7] with network priority low
declare global.number[8] with network priority low
declare global.number[9] with network priority low
declare global.number[10] with network priority low
declare global.number[11] with network priority low
declare global.object[0] with network priority local
declare global.object[1] with network priority local
declare global.player[0] with network priority local
declare global.player[1] with network priority local
declare global.team[0] with network priority low
declare player.number[0] with network priority local
declare player.number[1] with network priority low
declare player.number[2] with network priority low
declare player.number[3] with network priority low
declare player.number[4] with network priority low
declare player.number[5] with network priority local
declare player.number[6] with network priority low
declare player.object[0] with network priority low
declare player.timer[0] = 5
declare player.timer[1] = 5
declare player.timer[2] = 15
declare player.timer[3] = 5
declare object.timer[0] = 1

function get_rand_weapon_exclude_none()
   global.number[4] = rand(29)
   if global.number[4] == 0 then
      get_rand_weapon_exclude_none()
   end
end

function get_rand_weapon_default()
   global.number[4] = rand(21)
   if global.number[4] == 0 then
      get_rand_weapon_default()
   end
end

function get_rand_weapon_default_plus_turrets()
   global.number[4] = rand(23)
   if global.number[4] == 0 then
      get_rand_weapon_default_plus_turrets()
   end
end

function get_rand_weapon_default_plus_turrets_grenades()
   global.number[4] = rand(25)
   if global.number[4] == 0 then
      get_rand_weapon_default_plus_turrets_grenades()
   end
end

if game.teams_enabled == 1 then 
   for each object with label "ffa_only" do
      current_object.delete()
   end
end

if game.teams_enabled == 0 then 
   for each object with label "team_only" do
      current_object.delete()
   end
end

for each player do
   if current_player.is_elite() then 
      current_player.set_loadout_palette(elite_tier_1)
   end
   if not current_player.is_elite() then 
      current_player.set_loadout_palette(spartan_tier_1)
   end
   global.number[11] = 0
end

for each player do
   global.number[11] += 1
end

for each player do
   if game.score_to_win != 0 and game.teams_enabled == 1 then 
      current_player.set_round_card_title("Kill, headshot, and stick enemies to rule.\nRule the Throne to earn more points.\n%n points to win.", game.score_to_win)
   end
   if game.score_to_win != 0 and game.teams_enabled == 0 then 
      current_player.set_round_card_title("Get kills, headshots, and sticks to rule.\nRule the Throne to earn more points.\n%n points to win.", game.score_to_win)
   end
   if game.score_to_win == 0 and game.teams_enabled == 1 then 
      current_player.set_round_card_title("Kill, headshot, and stick enemies \nto take the Throne.\nRule the Throne to earn more points.")
   end
   if game.score_to_win == 0 and game.teams_enabled == 0 then 
      current_player.set_round_card_title("Get kills, headshots, and sticks\nto take the Throne.\nRule the Throne to earn more points.")
   end
end

for each player do
   current_player.timer[0].set_rate(-100%)
   if current_player.number[1] == 0 and current_player.timer[0].is_zero() then 
      game.show_message_to(current_player, announce_vip, "Frozen Throne\n\nKill enemy Kings when you can!")
      current_player.number[1] = 3
   end
   if current_player.timer[3].is_zero() and current_player.number[5] == 1 then 
      script_widget[0].set_visibility(current_player, false)
      script_widget[3].set_visibility(current_player, false)
      current_player.number[5] = 0
   end
end

for each player do
   global.number[4] = game.round_timer
   global.number[4] %= 10
   if global.number[4] == 0 and current_player.number[6] == 0 then 
      current_player.plasma_grenades += 1
      current_player.number[6] = 1
   end
   if global.number[4] != 0 and current_player.number[6] != 0 then 
      current_player.number[6] = 0
   end
end

for each player do
   if current_player.biped != no_object and current_player.number[1] == 2 then 
      current_player.timer[2].set_rate(-100%)
      script_widget[2].set_text("Weapons Ready in: %n", hud_player.timer[2])
      script_widget[2].set_visibility(current_player, true)
   end
   if current_player.timer[2].is_zero() then 
      current_player.number[1] = 3
      script_widget[2].set_visibility(current_player, false)
   end
end

for each player do
   global.number[1] = 0
   current_player.script_stat[0] = current_player.rating
   current_player.number[0] = 0
   if game.teams_enabled == 1 then 
      global.number[1] = current_player.team.get_scoreboard_pos()
   end
   if game.teams_enabled == 0 then 
      global.number[1] = current_player.get_scoreboard_pos()
   end
   if global.number[1] == 1 and not current_player.score == 0 then 
      current_player.number[0] = 1
   end
end

for each player do
   if current_player.number[0] == 0 then 
      current_player.timer[1].reset()
      current_player.timer[1].set_rate(0%)
      current_player.number[4] = 0
   end
   if current_player.number[0] == 1 and current_player.number[4] == 0 and not current_player.timer[1].is_zero() then 
      current_player.timer[1].reset()
      current_player.timer[1].set_rate(-100%)
      current_player.number[4] = 1
   end
end

for each player do
   global.player[0] = current_player
   if current_player.number[0] == 1 and current_player.number[4] == 1 then 
      game.play_sound_for(current_player, announce_koth_controlled, false)
      for each player do
         if current_player != global.player[0] then 
            if current_player.team == global.player[0].team then 
               game.show_message_to(current_player, announce_koth_controlled, "%s will be the new Frozen King!", global.player[0])
            end
            if current_player.team != global.player[0].team then 
               game.show_message_to(current_player, announce_koth_moved, "%s will be the new Frozen King!", global.player[0])
            end
         end
      end
      current_player.number[4] = 2
   end
   if current_player.number[0] == 1 and current_player.number[4] == 2 then 
      script_widget[0].set_text("You will be the new Frozen King!")
      script_widget[1].set_text("Respawning in: %n", hud_player.timer[1])
      script_widget[0].set_visibility(current_player, true)
      global.object[0] = no_object
      global.object[0] = current_player.biped
      if global.object[0] != no_object then 
         script_widget[1].set_visibility(current_player, true)
      end
      if global.object[0] == no_object then 
         script_widget[1].set_visibility(current_player, false)
      end
      if current_player.timer[1].is_zero() then 
         if global.number[11] <= 11 then 
            current_player.apply_traits(script_traits[0])
         end
         if global.number[11] >= 12 then 
            current_player.apply_traits(script_traits[1])
         end
         script_widget[0].set_visibility(current_player, false)
         script_widget[1].set_visibility(current_player, false)
         current_player.biped.kill(false)
         current_player.number[4] = 3
      end
   end
end

for each player do
   if current_player.number[0] == 1 and current_player.timer[1].is_zero() and current_player.number[4] >= 3 then 
      if global.number[11] <= 11 then 
         current_player.apply_traits(script_traits[0])
      end
      if global.number[11] >= 12 then 
         current_player.apply_traits(script_traits[1])
      end
      if current_player.number[4] == 3 and current_player.timer[2].is_zero() then 
         global.player[0] = current_player
         current_player.biped.set_waypoint_icon(vip)
         script_widget[0].set_text("FROZEN KING")
         script_widget[0].set_visibility(current_player, true)
         global.player[0] = current_player
         script_widget[3].set_text("New Frozen Throne")
         for each player do
            game.play_sound_for(current_player, announce_vip_new, false)
            if current_player != global.player[0] then 
               script_widget[3].set_visibility(current_player, true)
               if current_player.team == global.player[0].team then 
                  game.show_message_to(current_player, none, "Protect King %s!", global.player[0])
               end
               if current_player.team != global.player[0].team then 
                  game.show_message_to(current_player, none, "Kill King %s!", global.player[0])
               end
            end
            if current_player == global.player[0] then 
               game.show_message_to(current_player, none, "You have chosen a throne")
            end
            current_player.timer[3].reset()
            current_player.timer[3].set_rate(-100%)
            current_player.number[5] = 1
         end
         current_player.number[4] = 4
      end
      if current_player.number[4] == 4 then 
         current_player.apply_traits(script_traits[2])
      end
   end
end

for each player do
   if script_option[14] >= 1 and current_player.number[0] != 1 then 
      global.object[0] = no_object
      global.object[0] = current_player.biped
      global.object[1] = no_object
      global.object[1] = current_player.try_get_weapon(primary)
      if global.object[1].is_of_type(plasma_launcher) then 
         global.object[0].remove_weapon(primary, true)
      end
      global.object[1] = no_object
      global.object[1] = current_player.try_get_weapon(secondary)
      if global.object[1].is_of_type(plasma_launcher) then 
         global.object[0].remove_weapon(secondary, true)
      end
      if script_option[14] == 2 then
         global.number[4] = script_option[15]
         if global.number[4] == -1 then
            global.number[4] = rand(29)
         end
         if global.number[4] == -2 then
            global.number[4] = rand(28)
         end
         if global.number[4] == -3 then
            get_rand_weapon_exclude_none()
         end
         if global.number[4] == -4 then
            get_rand_weapon_default()
         end
         if global.number[4] == -5 then
            get_rand_weapon_default_plus_turrets()
         end
         if global.number[4] == -6 then
            get_rand_weapon_default_plus_turrets_grenades()
         end
         if global.number[4] > 0 then
            if global.number[4] == 1 then
               global.object[0].add_weapon(golf_club, primary)
            end
            if global.number[4] == 2 then
               global.object[0].add_weapon(magnum, primary)
            end
            if global.number[4] == 3 then
               global.object[0].add_weapon(assault_rifle, primary)
            end
            if global.number[4] == 4 then
               global.object[0].add_weapon(dmr, primary)
            end
            if global.number[4] == 5 then
               global.object[0].add_weapon(shotgun, primary)
            end
            if global.number[4] == 6 then
               global.object[0].add_weapon(sniper_rifle, primary)
            end
            if global.number[4] == 7 then
               global.object[0].add_weapon(rocket_launcher, primary)
            end
            if global.number[4] == 8 then
               global.object[0].add_weapon(spartan_laser, primary)
            end
            if global.number[4] == 9 then
               global.object[0].add_weapon(grenade_launcher, primary)
            end
            if global.number[4] == 10 then
               global.object[0].add_weapon(plasma_pistol, primary)
            end
            if global.number[4] == 11 then
               global.object[0].add_weapon(needler, primary)
            end
            if global.number[4] == 12 then
               global.object[0].add_weapon(plasma_rifle, primary)
            end
            if global.number[4] == 13 then
               global.object[0].add_weapon(plasma_repeater, primary)
            end
            if global.number[4] == 14 then
               global.object[0].add_weapon(needle_rifle, primary)
            end
            if global.number[4] == 15 then
               global.object[0].add_weapon(spiker, primary)
            end
            if global.number[4] == 16 then
               global.object[0].add_weapon(gravity_hammer, primary)
            end
            if global.number[4] == 17 then
               global.object[0].add_weapon(energy_sword, primary)
            end
            if global.number[4] == 18 then
               global.object[0].add_weapon(concussion_rifle, primary)
            end
            if global.number[4] == 21 then
               global.object[0].add_weapon(focus_rifle, primary)
            end
            if global.number[4] == 22 then
               global.object[0].add_weapon(fuel_rod_gun, primary)
            end
            if global.number[4] == 21 then
               global.object[0].add_weapon(detached_machine_gun_turret, force)
            end
            if global.number[4] == 22 then
               global.object[0].add_weapon(detached_plasma_cannon, force)
            end
            if global.number[4] == 23 then
               current_player.frag_grenades += 2
            end
            if global.number[4] == 24 then
               current_player.plasma_grenades += 2
            end
            if global.number[4] == 25 then
               global.object[0].add_weapon(flag, primary)
            end
            if global.number[4] == 26 then
               global.object[0].add_weapon(bomb, primary)
            end
            if global.number[4] == 27 then
               global.object[0].add_weapon(skull, primary)
            end
            if global.number[4] == 28 then
               global.object[0].add_weapon(target_locator, primary)
            end
         end
      end
   end
end

for each player do
   global.number[1] = 0
   global.object[0] = no_object
   global.object[0] = current_player.biped
   if global.object[0] != no_object then 
      current_player.object[0] = global.object[0]
   end
   if current_player.killer_type_is(guardians | suicide | kill | betrayal | quit) then 
      current_player.timer[2].reset()
      current_player.timer[2].set_rate(0%)
      current_player.number[1] = 2
      current_player.score += script_option[2]
      if current_player.killer_type_is(kill) then 
         global.player[0] = current_player.try_get_killer()
         global.player[0].score += script_option[1]
         do
            global.number[2] = 0
            global.number[3] = 0
            global.number[3] = current_player.try_get_death_damage_type()
            if global.number[3] == enums.damage_reporting_type.plasma_launcher and global.player[0].number[0] == 1 and global.player[0].number[4] >= 4 then 
               global.player[0].score += script_option[10]
            end
            if global.number[3] == 6 then 
               global.number[2] = current_player.object[0].get_distance_to(global.player[0].object[0])
               if global.number[2] > 400 then 
                  send_incident(dlc_achieve_5, global.player[0], current_player)
               end
            end
         end
         global.number[0] = current_player.try_get_death_damage_mod()
         global.number[1] = global.player[0].get_spree_count()
         do
            global.number[1] -= 5
            if global.number[1] >= 0 then 
               global.player[0].score += script_option[11]
            end
         end
         if current_player.number[0] == 1 and current_player.number[4] >= 4 then 
            global.player[0].score += script_option[5]
            send_incident(vip_kill, global.player[0], current_player)
            game.show_message_to(all_players, none, "%s killed King %s", global.player[0], current_player)
            current_player.biped.set_waypoint_icon(none)
         end
         if global.number[0] == 1 then 
            global.player[0].score += script_option[7]
         end
         if global.number[0] == 2 then 
            if current_player.number[0] == 1 and current_player.number[3] >= 4 then
               global.player[0].score += script_option[8]
            end
            if current_player.number[0] != 1 or current_player.number[3] < 4 then
               global.player[0].score += script_option[7]
            end
         end
         if global.number[0] == 3 then 
            global.player[0].score += script_option[9]
         end
         if global.number[0] == 4 then 
            global.player[0].score += script_option[10]
         end
         if global.number[0] == 5 then 
            global.player[0].score += script_option[6]
         end
      end
      if current_player.number[0] == 1 and current_player.number[4] >= 4 then 
         current_player.number[4] = 1
      end
   end
end

for each player do
   if current_player.killer_type_is(guardians | suicide | kill | betrayal | quit) and not current_player.killer_type_is(kill) and not current_player.killer_type_is(betrayal) then 
      global.number[3] = current_player.try_get_death_damage_type()
      if global.number[3] != 2 then 
         if current_player.number[0] != 1 then 
            current_player.score += script_option[3]
         end
         if current_player.number[0] == 1 and current_player.number[4] >= 3 then 
            current_player.score += script_option[13]
         end
      end
   end
end

for each player do
   if current_player.killer_type_is(betrayal) then 
      global.player[0] = current_player.try_get_killer()
      global.player[0].score += script_option[4]
   end
end

if game.round_time_limit > 0 and game.round_timer.is_zero() then 
   game.end_round()
end

for each player do
   if script_option[12] == 1 then 
      global.number[1] = 0
      global.number[1] = current_player.biped.shields
      if global.number[1] > 100 then 
         global.number[2] = 0
         global.number[2] = rand(10)
         if global.number[2] <= 2 then 
            current_player.biped.place_at_me(particle_emitter_fire, none, never_garbage_collect, 0, 0, 0, none)
         end
      end
   end
end

for each object with label 3 do
   current_object.timer[0].set_rate(-100%)
   if current_object.timer[0].is_zero() then 
      current_object.delete()
   end
end

for each player do
   if current_player.killer_type_is(kill) then 
      global.player[1] = no_player
      global.player[0] = current_player.try_get_killer()
      global.number[1] = 0
      global.number[0] = current_player.try_get_death_damage_mod()
      if global.number[0] == 2 then 
         global.object[0] = no_object
         global.object[0] = global.player[0].try_get_armor_ability()
         if global.object[0].has_forge_label(5) and global.object[0].is_in_use() then 
            send_incident(dlc_achieve_2, global.player[0], global.player[0], 65)
         end
      end
   end
end

for each player do
   if current_player.killer_type_is(kill) then 
      global.number[1] = 0
      global.number[0] = current_player.try_get_death_damage_mod()
      if global.number[0] == 4 then 
         global.player[1] = no_player
         global.player[0] = current_player.try_get_killer()
         if global.player[0].killer_type_is(suicide) then 
            send_incident(dlc_achieve_2, current_player, current_player, 68)
         end
      end
   end
end

for each player do
   if current_player.killer_type_is(guardians | suicide | kill | betrayal | quit) then 
      current_player.number[2] = 0
      if current_player.killer_type_is(kill) then 
         global.player[1] = no_player
         global.player[0] = current_player.try_get_killer()
         global.number[1] = 0
         global.number[0] = current_player.try_get_death_damage_mod()
         if global.number[0] != 5 then 
            global.player[0].number[2] = 0
         end
         if global.number[0] == 5 then 
            global.player[0].number[2] += 1
            if global.player[0].number[2] > 2 then 
               send_incident(dlc_achieve_2, global.player[0], global.player[0], 62)
            end
         end
      end
   end
end

for each player do
   if current_player.killer_type_is(kill) then 
      global.player[1] = no_player
      global.player[0] = current_player.try_get_killer()
      global.number[1] = 0
      global.number[0] = current_player.try_get_death_damage_mod()
      global.object[0] = no_object
      global.object[0] = global.player[0].try_get_vehicle()
      if global.object[0] != no_object and global.number[0] == 3 then 
         global.player[0].number[3] += 1
         if global.player[0].number[3] > 4 then 
            send_incident(dlc_achieve_2, global.player[0], global.player[0], 66)
         end
      end
   end
end

for each player do
   if current_player.killer_type_is(kill) and not current_player.timer[1].is_zero() then 
      global.number[1] = 0
      global.number[0] = current_player.try_get_death_damage_mod()
      if global.number[0] == 2 then 
         global.player[1] = no_player
         global.player[0] = current_player.try_get_killer()
         send_incident(dlc_achieve_2, global.player[0], global.player[0], 60)
      end
   end
end
