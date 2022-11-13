
declare global.number[0] with network priority local
declare global.number[1] with network priority local
declare global.number[2] with network priority low
declare global.number[3] with network priority local
declare global.number[4] with network priority local
declare global.number[5] with network priority low
declare global.number[6] with network priority low
declare global.object[0] with network priority local
declare global.object[1] with network priority local
declare global.object[2] with network priority low
declare global.player[0] with network priority local
declare global.player[1] with network priority local
declare global.player[2] with network priority low
declare global.team[0] with network priority local
declare global.timer[1] = script_option[11]
declare player.number[0] with network priority low
declare player.number[1] with network priority low
declare player.number[2] with network priority low
declare player.number[3] with network priority low
declare player.number[4] with network priority low
declare player.number[5] with network priority low
declare player.number[6] with network priority low
declare player.timer[0] = script_option[10]
declare player.timer[1] = 10
declare player.timer[2] = 2
declare player.timer[3] = 2
declare object.number[0] with network priority low
declare object.number[1] with network priority low = 1
declare object.number[2] with network priority local
declare object.number[3] with network priority local
declare object.object[0] with network priority low
declare object.player[0] with network priority low
declare object.timer[0] = script_option[1]
declare object.timer[1] = script_option[0]
declare object.timer[2] = 3
declare team.object[0] with network priority low
declare team.object[1] with network priority low

do
   global.number[0] = 0
end

on pregame: do
   game.symmetry = 1
   if script_option[2] == 1 then 
      game.symmetry = 0
   end
end

for each player do
   if current_player.is_elite() then 
      current_player.set_loadout_palette(elite_tier_1)
   end
   if not current_player.is_elite() then 
      current_player.set_loadout_palette(spartan_tier_1)
   end
end

for each player do
   if script_option[2] == 1 and current_player.team == team[1] then 
      current_player.set_round_card_title("Capture the enemy flag.\r\n%n rounds.", game.round_limit)
      current_player.set_round_card_text("Offense")
      current_player.set_round_card_icon(attack)
   end
   if script_option[2] == 1 and current_player.team == team[0] then 
      current_player.set_round_card_title("Defend your flag.\r\n%n rounds.", game.round_limit)
      current_player.set_round_card_text("Defense")
      current_player.set_round_card_icon(defend)
   end
   if game.score_to_win != 0 and script_option[2] == 2 or script_option[2] == 0 then 
      current_player.set_round_card_title("Capture the flag.\r\n%n points to win.", game.score_to_win)
   end
   if game.score_to_win == 0 and script_option[2] == 2 or script_option[2] == 0 then 
      current_player.set_round_card_title("Capture the flag.")
   end
end

if script_option[11] != -1 and global.timer[1].is_zero() then
   for each player do
      game.show_message_to(current_player, none, "Evade has some invincibility frames; use them wisely")
      game.show_message_to(current_player, none, "Crouch 4 times to swap abilities")
   end
   global.timer[1].reset()
end


for each player do
   current_player.timer[0].set_rate(-100%)
   if script_option[10] != -1 then
      if current_player.timer[0].is_zero() then
         current_player.plasma_grenades += 1
         current_player.timer[0].reset()
      end
   end
end



for each player do
   global.timer[1].set_rate(-100%)
   script_widget[0].set_text("Your flag must be at home to score!")
   script_widget[0].set_visibility(current_player, false)
   script_widget[1].set_visibility(current_player, true)
   script_widget[2].set_text("iFrames: %n", script_option[9])
   script_widget[2].set_visibility(current_player, false)
   script_widget[3].set_text(">>INVINCIBLE<<")
   script_widget[3].set_visibility(current_player, false)
   if current_player.number[0] == 0 then
      script_widget[1].set_meter_params(timer, hud_player.timer[1])
      current_player.timer[1].set_rate(-500%)
   end
   if current_player.number[0] == 0 and current_player.timer[2].is_zero() then 
      global.number[6] = script_option[4]
      global.number[6] *= 60
      current_player.number[6] = -1
      game.show_message_to(current_player, none, "(v1.0)  -  Rolls added by mini nt")
      game.show_message_to(current_player, announce_ctf, "Castle Wars: Dark Souls")
      current_player.number[0] = 1
      if script_option[2] == 1 and current_player.team == team[1] then 
         send_incident(team_offense, current_player, no_player)
      end
      if script_option[2] == 1 and current_player.team == team[0] then 
         send_incident(team_defense, current_player, no_player)
      end
   end
end

for each player do
   global.object[4] = current_player.biped
   if global.object[4] != no_object then
      global.object[4].player[0] = current_player
   end
end

on local: do
   for each player do
      global.object[3] = current_player.get_armor_ability()
      if global.object[3].is_of_type(armor_lock) and global.object[3].is_in_use() then
         current_player.number[4] = 9
      end
      if global.object[3].is_of_type(evade) and global.object[3].is_in_use() then
         current_player.number[4] = 9
      end
      if global.object[3].is_of_type(drop_shield) and global.object[3].is_in_use() then
         current_player.number[4] = 9
      end
   end

   for each player do
      current_player.timer[2].set_rate(-100%)
      global.number[5] = 0
      global.object[3] = current_player.biped
      global.object[2] = current_player.biped.place_at_me(hill_marker, none, none, 0, 0, 1, none)
      global.object[2].attach_to(global.object[3], 0, 0, 0, relative)
      global.object[2].detach()
      global.number[5] = current_player.biped.get_distance_to(global.object[2])
      global.object[2].delete()
      if current_player.is_spartan() then 
         if global.number[5] <= 2 and current_player.number[4] == 0 then 
            current_player.number[4] = 1
            current_player.timer[2].reset()
         end
         if global.number[5] >= 3 and current_player.number[4] == 1 then 
            current_player.number[4] = 2
            current_player.timer[2].reset()
         end
         if global.number[5] <= 2 and current_player.number[4] == 2 then 
            current_player.number[4] = 3
            current_player.timer[2].reset()
         end
         if global.number[5] >= 3 and current_player.number[4] == 3 then 
            current_player.number[4] = 4
            current_player.timer[2].reset()
         end
         if global.number[5] <= 2 and current_player.number[4] == 4 then 
            current_player.number[4] = 5
            current_player.timer[2].reset()
         end
         if global.number[5] >= 3 and current_player.number[4] == 5 then 
            current_player.number[4] = 6
            current_player.timer[2].reset()
         end
         if global.number[5] <= 2 and current_player.number[4] == 6 then 
            current_player.number[4] = 7
            current_player.timer[2].reset()
         end
         if global.number[5] >= 3 and current_player.number[4] == 7 then 
            current_player.number[4] = 8
            current_player.timer[2].reset()
         end
      end
      if current_player.is_elite() then 
         if global.number[5] >= 4 and current_player.number[4] == 7 then 
            current_player.number[4] = 8
            current_player.timer[2].reset()
         end
         if global.number[5] <= 3 and current_player.number[4] == 6 then 
            current_player.number[4] = 7
            current_player.timer[2].reset()
         end
         if global.number[5] >= 4 and current_player.number[4] == 5 then 
            current_player.number[4] = 6
            current_player.timer[2].reset()
         end
         if global.number[5] <= 3 and current_player.number[4] == 4 then 
            current_player.number[4] = 5
            current_player.timer[2].reset()
         end
         if global.number[5] >= 4 and current_player.number[4] == 3 then 
            current_player.number[4] = 4
            current_player.timer[2].reset()
         end
         if global.number[5] <= 3 and current_player.number[4] == 2 then 
            current_player.number[4] = 3
            current_player.timer[2].reset()
         end
         if global.number[5] >= 4 and current_player.number[4] == 1 then 
            current_player.number[4] = 2
            current_player.timer[2].reset()
         end
         if global.number[5] <= 3 and current_player.number[4] == 0 then 
            current_player.number[4] = 1
            current_player.timer[2].reset()
         end
      end
      if current_player.timer[1].is_zero() and current_player.timer[2].is_zero() then 
         current_player.number[4] = 0
         current_player.number[5] = 0
      end
   end
end

for each player do
   global.object[4] = current_player.get_armor_ability()

   if current_player.number[4] == 8 and current_player.number[5] == 0 then
      if global.object[4].is_of_type(evade) then
         global.object[3] = current_player.biped.place_at_me(sprint, none, none, 0, 0, 1, none)
         game.show_message_to(current_player, none, "Sprint equipped")
      end
      if global.object[4].is_of_type(sprint) then
         global.object[3] = current_player.biped.place_at_me(evade, none, none, 0, 0, 1, none)
         game.show_message_to(current_player, none, "Evade equipped")
      end
      global.object[4].delete()
      global.object[3].attach_to(current_player.biped, 0, 0, 1, relative)
      global.object[3].detach()
      current_player.number[4] = 9
      current_player.number[5] = 1
      current_player.timer[1].reset()
      current_player.timer[1].set_rate(-500%)
      current_player.timer[3].reset()
      current_player.timer[3].set_rate(-200%)
   end
   global.object[4] = current_player.get_armor_ability()
   if global.object[4].is_of_type(evade) then
      if script_option[7] == 1 and not current_player.timer[3].is_zero() then
         current_player.timer[3].set_rate(-300%)
         current_player.apply_traits(script_traits[3])
      end
      if script_option[8] == 1 then
         if global.object[4].is_in_use() then
            if current_player.number[3] <= script_option[9] then
               script_widget[2].set_visibility(current_player, false)
               script_widget[3].set_visibility(current_player, true)
               current_player.apply_traits(script_traits[2])
               current_player.number[3] += 1
            end
            if current_player.number[3] > script_option[9] then
               script_widget[2].set_visibility(current_player, true)
               script_widget[3].set_visibility(current_player, false)
            end
         end
         if script_option[7] == 1 then
            if not global.object[4].is_in_use() and current_player.timer[3].is_zero() then
               script_widget[2].set_visibility(current_player, true)
               script_widget[3].set_visibility(current_player, false)
               current_player.number[3] = 0
            end
         end
         if script_option[7] != 1 then
            if not global.object[4].is_in_use() then
               script_widget[2].set_visibility(current_player, true)
               script_widget[3].set_visibility(current_player, false)
               current_player.number[3] = 0
            end
         end
      end
   end
   if global.object[4].is_of_type(sprint) then
      script_widget[2].set_visibility(current_player, false)
      script_widget[3].set_visibility(current_player, false)
      if script_option[7] == 1 then
         current_player.apply_traits(script_traits[3])
      end
   end
end

for each team do
   if current_team.object[0] == no_object then 
      for each object with label "ctf_flag_return" do
         if current_team.object[0] == no_object and current_object.team == current_team then 
            current_team.object[0] = current_object
            current_object.set_waypoint_visibility(allies)
            current_object.set_waypoint_icon(diamond)
         end
      end
   end
end

for each team do
   current_team.object[1].set_waypoint_visibility(everyone)
   if current_team == neutral_team or current_team.has_any_players() and current_team.object[1] == no_object and not current_team.object[0] == no_object then 
      global.number[3] = 0
      if script_option[2] == 0 and not current_team == neutral_team and current_team.has_any_players() then 
         global.number[3] = 1
      end
      if script_option[2] == 1 and current_team == team[0] then 
         team[1].object[0].set_waypoint_visibility(everyone)
         team[0].object[0].set_waypoint_visibility(no_one)
         global.number[3] = 1
      end
      if script_option[2] == 2 and current_team == neutral_team then 
         global.number[3] = 1
      end
      if global.number[3] == 1 then 
         if script_option[2] == 1 or script_option[2] == 2 then 
            for each object do
               if current_object.is_of_type(flag) then 
                  current_team.object[1] = current_object
                  global.number[3] = 0
               end
            end
         end
         if script_option[2] == 0 then 
            for each object do
               if current_object.is_of_type(flag) and global.number[3] == 1 then 
                  global.number[4] = 1
                  do
                     global.player[1] = no_player
                     global.player[1] = current_object.try_get_carrier()
                     if not global.player[1] == no_player and global.player[1].team == current_team then 
                        global.number[4] = 0
                     end
                  end
                  for each team do
                     if current_team.object[1] == current_object then 
                        global.number[4] = 0
                     end
                  end
                  if global.number[4] == 1 then 
                     current_team.object[1] = current_object
                     global.number[3] = 0
                  end
               end
            end
         end
         if global.number[3] == 1 then 
            current_team.object[1] = current_team.object[0].place_at_me(flag, none, never_garbage_collect, 0, 0, 3, none)
         end
         global.object[0] = current_team.object[1]
         if global.number[3] == 0 then 
            global.object[0].number[0] = 1
         end
         global.object[0].team = current_team
         current_team.object[1].set_pickup_permissions(enemies)
         current_team.object[1].set_weapon_pickup_priority(high)
         current_team.object[1].set_waypoint_icon(flag)
         current_team.object[1].set_waypoint_priority(high)
         global.object[0].set_shape(cylinder, 7, 6, 3)
         if script_option[2] == 2 then 
            current_team.object[1].set_pickup_permissions(everyone)
         end
      end
   end
end

for each player do
   current_player.biped.set_waypoint_icon(none)
end

for each team do
   global.object[0] = current_team.object[1]
   global.player[1] = no_player
   global.number[2] = 0
   global.player[1] = global.object[0].try_get_carrier()
   if not global.player[1] == no_player then 
      global.object[0].player[0] = global.player[1]
      global.player[1].apply_traits(script_traits[0])
   end
   if not global.player[1] == no_player then 
      global.object[0].set_waypoint_visibility(no_one)
      global.player[1].biped.set_waypoint_icon(flag)
      global.object[0].number[0] = 1
      global.object[0].timer[0] = script_option[1]
      global.object[0].timer[1] = script_option[0]
      global.object[0].set_progress_bar(0, no_one)
      global.number[0] = 1
      global.team[0] = global.player[1].team
      if global.team[0].object[0].shape_contains(global.player[1].biped) then 
         global.number[3] = 1
         script_widget[0].set_visibility(global.player[1], false)
         if script_option[3] == 1 and script_option[2] == 0 then 
            global.object[1] = global.team[0].object[1]
            if not global.object[1].number[0] == 0 then 
               global.number[3] = 0
               script_widget[0].set_visibility(global.player[1], true)
            end
         end
         if global.number[3] == 1 then 
            global.player[1].score += 1
            global.player[1].script_stat[0] += 1
            current_team.object[1].delete()
            send_incident(flag_scored, global.player[1], all_players)
         end
      end
   end
   if global.player[1] == no_player and global.object[0].number[0] == 1 then 
      global.object[0].number[0] = 2
      if script_option[0] != 1 then 
         global.object[0].set_progress_bar(1, allies)
      end
      global.object[0].set_waypoint_icon(flag)
      global.object[0].set_waypoint_visibility(everyone)
      current_team.object[1].set_waypoint_priority(high)
   end
end

for each team do
   global.object[0] = current_team.object[1]
   if not global.object[0] == no_object and global.object[0].number[0] == 2 or global.object[0].number[0] == 3 then 
      global.object[0].timer[0].set_rate(-100%)
      global.object[0].timer[1].set_rate(100%)
      for each player do
         current_player.number[1] = 0
         if current_player.team == current_team and global.object[0].shape_contains(current_player.biped) then 
            current_player.number[1] = 1
            global.object[0].timer[1].set_rate(-100%)
            if script_option[0] == 1 then 
               global.object[0].timer[1].set_rate(-1000%)
            end
            global.object[0].set_waypoint_priority(blink)
         end
      end
      for each object with label 5 do
         if current_object.timer[0] < 6 then 
            current_object.set_waypoint_priority(blink)
         end
      end
      if global.object[0].is_out_of_bounds() or global.object[0].timer[0].is_zero() then 
         global.object[0].delete()
         if script_option[2] == 2 then 
            send_incident(flag_reset_neutral, global.object[0].player[0], current_team)
         end
         if not script_option[2] == 2 then 
            send_incident(flag_reset, current_team, current_team)
         end
      end
      if global.object[0].timer[1].is_zero() then 
         global.object[0].delete()
         send_incident(flag_recovered, current_team, current_team)
         for each player do
            if current_player.number[1] == 1 and current_player.team == current_team then 
               current_player.script_stat[2] += 1
               current_player.number[1] = 0
            end
         end
      end
   end
end

for each team do
   global.object[0] = current_team.object[1]
   global.object[1] = global.object[0].player[0].biped
   global.player[1] = global.object[0].player[0]
   global.object[0].timer[2].set_rate(-100%)
   if global.object[0].timer[2].is_zero() then 
      if global.object[0].number[0] == 2 and global.object[0].number[3] != 1 then 
         global.object[0].number[3] = 1
         if script_option[2] == 2 then 
            send_incident(flag_dropped_neutral, global.object[0].player[0], current_team)
         end
         if not script_option[2] == 2 then 
            send_incident(flag_dropped, global.object[0].player[0], current_team)
         end
         global.object[0].timer[2].reset()
      end
      if global.object[0].number[0] == 1 and global.object[0].number[2] != 1 then 
         global.object[0].number[2] = 1
         if script_option[2] == 2 then 
            send_incident(flag_grabbed_neutral, global.player[1], current_team)
         end
         if not script_option[2] == 2 then 
            send_incident(flag_grabbed, global.player[1], current_team)
         end
         global.object[0].timer[2].reset()
      end
      if global.object[0].number[0] != 1 then 
         global.object[0].number[2] = 0
      end
      if global.object[0].number[0] == 1 or global.object[0].number[0] == 0 then 
         global.object[0].number[3] = 0
      end
   end
end

for each object with label 5 do
   current_object.player[0] = no_player
   current_object.player[0] = current_object.get_carrier()
   if current_object.player[0] != no_player then
      global.player[2] = current_object.player[0]
      global.player[2].number[6] = 0
   end
end

for each player do
   global.object[0] = current_player.biped
   if not global.object[0] == no_object then 
      global.object[1] = no_object
      global.object[1] = current_player.try_get_weapon(primary)
      if not global.object[1].is_of_type(flag) and current_player.number[6] >= 0 then 
         if current_player.number[6] <= global.number[6] then 
            current_player.apply_traits(script_traits[1])
            current_player.number[6] += 1
         end
         if current_player.number[6] > global.number[6] then 
            current_player.number[6] = -1
         end
      end
   end
end

for each team do
   if current_team.has_any_players() then 
      global.object[0] = current_team.object[1]
      for each player do
         if global.object[0].player[0].killer_type_is(kill) then 
            global.player[0] = global.object[0].player[0].try_get_killer()
            send_incident(flagcarrier_kill, global.player[0], global.object[0].player[0])
            global.object[0].player[0] = no_player
         end
      end
   end
end

for each object with label 5 do
   if current_object.object[0] == no_object then 
      current_object.object[0] = current_object.place_at_me(hill_marker, none, never_garbage_collect | suppress_effect, 0, 0, 0, none)
      current_object.object[0].set_shape(cylinder, script_option[6], 10, 10)
      current_object.object[0].set_shape_visibility(no_one)
      current_object.object[0].attach_to(current_object, 0, 0, 0, relative)
   end
end

for each object with label 5 do
   if script_option[2] == 1 then 
      global.object[0] = current_object
      for each player do
         if not current_player.team == global.object[0].team and global.object[0].object[0].shape_contains(current_player.biped) then 
            global.number[2] = 1
            global.object[0].timer[0].set_rate(0%)
         end
      end
   end
end

for each object with label 5 do
   global.object[0] = current_object
   if not global.object[0].player[0] == no_player then 
      for each player do
         if current_player == global.object[0].player[0] then 
            global.player[1] = no_player
            global.player[1] = global.object[0].try_get_carrier()
            if global.player[1] == no_player then 
               global.object[0].player[0] = no_player
            end
         end
      end
   end
end

for each team do
   if current_team.has_any_players() then 
      global.object[0] = current_team.object[1]
      if not global.object[0] == no_object then 
         for each object with label "ctf_res_zone" do
            if current_object.team == current_team then 
               current_object.enable_spawn_zone(0)
               current_object.set_shape_visibility(no_one)
               current_object.set_invincibility(1)
               current_object.set_pickup_permissions(no_one)
               if global.object[0].number[0] == 0 then 
                  current_object.enable_spawn_zone(1)
               end
            end
         end
         for each object with label "ctf_res_zone_away" do
            if current_object.team == current_team then 
               current_object.enable_spawn_zone(0)
               current_object.set_shape_visibility(no_one)
               current_object.set_invincibility(1)
               current_object.set_pickup_permissions(no_one)
               if not global.object[0].number[0] == 0 then 
                  current_object.enable_spawn_zone(1)
               end
            end
         end
      end
   end
end

for each team do
   if current_team != neutral_team and not current_team.has_any_players() and current_team.object[1] != no_object then 
      global.object[0] = current_team.object[1]
      if global.object[0].number[0] == 0 then 
         current_team.object[1].delete()
         current_team.object[1] = no_object
      end
   end
end

if not game.round_timer.is_zero() then 
   game.grace_period_timer = 0
end

if game.round_time_limit > 0 then 
   if not game.round_timer.is_zero() then 
      global.number[1] = 0
   end
   if game.round_timer.is_zero() then 
      if global.number[0] == 1 then 
         game.sudden_death_timer.set_rate(-100%)
         game.grace_period_timer.reset()
         if global.number[1] == 0 then 
            send_incident(sudden_death, all_players, all_players)
            global.number[1] = 1
         end
         if game.sudden_death_time > 0 and game.grace_period_timer > game.sudden_death_timer then 
            game.grace_period_timer = game.sudden_death_timer
         end
      end
      if global.number[0] == 0 then 
         game.grace_period_timer.set_rate(-100%)
         if game.grace_period_timer.is_zero() then 
            game.end_round()
         end
      end
      if game.sudden_death_timer.is_zero() then 
         game.end_round()
      end
   end
end
