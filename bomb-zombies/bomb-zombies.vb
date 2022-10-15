
declare global.number[0] with network priority low
declare global.number[1] with network priority local
declare global.number[2] with network priority low
declare global.number[3] with network priority local
declare global.number[4] with network priority local
declare global.number[5] with network priority low
declare global.number[6] with network priority low
declare global.number[7] with network priority low
declare global.number[8] with network priority low
declare global.number[9] with network priority low
declare global.number[10] with network priority low
declare global.number[11] with network priority low
declare global.object[0] with network priority low
declare global.object[1] with network priority local
declare global.object[2] with network priority low
declare global.object[3] with network priority low
declare global.player[0] with network priority local
declare global.player[1] with network priority local
declare global.team[0] with network priority low
declare global.team[1] with network priority low
declare global.timer[0] = script_option[3]
declare global.timer[1] = 10
declare player.number[0] with network priority low
declare player.number[1] with network priority low
declare player.number[2] with network priority low = 1
declare player.number[3] with network priority low
declare player.number[4] with network priority low
declare player.number[5] with network priority low
declare player.object[0] with network priority low
declare player.object[1] with network priority low
declare player.object[2] with network priority low
declare player.object[3] with network priority low
declare player.timer[0] = script_option[13]
declare player.timer[1] = 5
declare player.timer[2] = 1
declare player.timer[3] = 2
declare object.number[0] with network priority low
declare object.timer[0] = script_option[3]
declare object.timer[1] = script_option[13]

for each player do
   if current_player.number[0] != 1 then 
      if current_player.is_elite() then 
         current_player.set_loadout_palette(elite_tier_1)
      end
      if not current_player.is_elite() then 
         current_player.set_loadout_palette(spartan_tier_1)
      end
   end
   if current_player.number[0] == 1 then 
      if current_player.is_elite() then 
         current_player.set_loadout_palette(elite_tier_2)
      end
      if not current_player.is_elite() then 
         current_player.set_loadout_palette(spartan_tier_2)
      end
   end
end

do
   global.number[3] = 0
   global.number[4] = -1
   for each player do
      global.number[4] += 1
      if current_player.number[0] == 1 then 
         global.number[3] += 1
      end
   end
   for each player randomly do
      if global.number[3] < script_option[0] and global.number[3] < global.number[4] and current_player.number[1] != 1 and current_player.number[0] != 1 then 
         current_player.number[0] = 1
         global.number[3] += 1
      end
   end
   for each player do
      if current_player.number[0] == 1 and current_player.team != team[1] then 
         send_incident(inf_new_zombie, current_player, no_player)
         current_player.team = team[1]
         current_player.apply_traits(script_traits[0])
         current_player.biped.kill(true)
      end
   end
end

on local: do
   for each player do
      if current_player.number[0] == 1 then 
         current_player.timer[3].set_rate(-100%)
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
               current_player.timer[3].reset()
            end
            if global.number[5] >= 3 and current_player.number[4] == 1 then 
               current_player.number[4] = 2
               current_player.timer[3].reset()
            end
            if global.number[5] <= 2 and current_player.number[4] == 2 then 
               current_player.number[4] = 3
               current_player.timer[3].reset()
            end
            if global.number[5] >= 3 and current_player.number[4] == 3 then 
               current_player.number[4] = 4
               current_player.timer[3].reset()
            end
         end
         if current_player.is_elite() then 
            if global.number[5] >= 4 and current_player.number[4] == 3 then 
               current_player.number[4] = 4
               current_player.timer[3].reset()
            end
            if global.number[5] <= 3 and current_player.number[4] == 2 then 
               current_player.number[4] = 3
               current_player.timer[3].reset()
            end
            if global.number[5] >= 4 and current_player.number[4] == 1 then 
               current_player.number[4] = 2
               current_player.timer[3].reset()
            end
            if global.number[5] <= 3 and current_player.number[4] == 0 then 
               current_player.number[4] = 1
               current_player.timer[3].reset()
            end
         end
         if current_player.timer[3].is_zero() then 
            current_player.number[4] = 0
         end
      end
   end
end

for each player do
   script_widget[0].set_text("Safe Haven - %s", global.timer[0])
   script_widget[0].set_visibility(current_player, false)
end

for each player do
   current_player.timer[1].set_rate(-100%)
   for each player do
      if current_player.team == team[0] then 
         current_player.set_round_card_title("Dive away from the zombie bombs!")
      end
   end
   for each player do
      if current_player.team == team[1] then 
         current_player.set_round_card_title("Crouch twice to drop bombs on those\npesky humans!")
      end
   end
end

for each player do
   if current_player.number[3] == 0 and current_player.timer[1].is_zero() then 
      send_incident(infection_game_start, current_player, no_player)
      current_player.number[3] = 1
   end
   global.object[3] = no_object
   global.object[3] = current_player.biped
   if current_player.number[3] == 1 and global.object[3] != no_object then 
      global.object[2] = global.object[3].place_at_me(capture_plate, none, none, 0, 0, 1, none)
      global.object[2].attach_to(global.object[3], 0, 0, -30, relative)
      current_player.object[0] = global.object[2]
      current_player.number[3] = 2
   end
end

for each player do
   if current_player.team == team[1] and current_player.number[4] == 4 and current_player.timer[0].is_zero() then 
      global.object[3] = current_player.object[0].place_at_me(fusion_coil, "inf_NO_USE_zombie_bomb", none, 7, 0, 7, none)
      global.object[3].timer[1].reset()
      global.object[3].timer[1].set_rate(-100%)
      global.object[3] = current_player.object[0].place_at_me(fusion_coil, "inf_NO_USE_zombie_bomb", none, -7, 0, 7, none)
      global.object[3].timer[1].reset()
      global.object[3].timer[1].set_rate(-100%)
      global.object[3] = current_player.object[0].place_at_me(fusion_coil, "inf_NO_USE_zombie_bomb", none, 0, 7, 7, none)
      global.object[3].timer[1].reset()
      global.object[3].timer[1].set_rate(-100%)
      global.object[3] = current_player.object[0].place_at_me(fusion_coil, "inf_NO_USE_zombie_bomb", none, 0, -7, 7, none)
      current_player.timer[0].reset()
   end
end

for each object with label "inf_NO_USE_zombie_bomb" do
   if current_object.timer[1].is_zero() then 
      current_object.kill(false)
   end
end

for each player do
   current_player.team = team[0]
   if current_player.number[0] == 1 then 
      current_player.team = team[1]
      current_player.apply_traits(script_traits[0])
   end
end

for each player do
   if current_player.killer_type_is(guardians | suicide | kill | betrayal | quit) then 
      current_player.number[1] = 0
      global.player[0] = current_player
      global.player[1] = no_player
      global.player[1] = current_player.try_get_killer()
      if current_player.killer_type_is(kill) and global.player[0].number[0] == 1 and global.player[0].number[0] != global.player[1].number[0] then 
         global.player[1].score += script_option[7]
         send_incident(zombie_kill_kill, global.player[1], global.player[0])
      end
      if current_player.killer_type_is(kill) and script_option[2] == 1 and global.player[0].number[0] == 1 and global.player[0].number[0] != global.player[1].number[0] and global.player[1].number[2] == 1 then 
         global.player[1].score += script_option[6]
      end
      if current_player.killer_type_is(kill) and not global.player[1] == no_player and global.player[0].number[0] == 0 then 
         global.player[0].number[0] = 1
         send_incident(inf_new_infection, global.player[1], global.player[0])
         send_incident(infection_kill, global.player[1], global.player[0])
         global.player[1].score += script_option[10]
         global.player[1].script_stat[1] += 1
      end
      if current_player.killer_type_is(suicide) then 
         global.player[1].score += script_option[8]
         if script_option[12] == 1 then 
            global.player[0].number[0] = 1
         end
      end
      if current_player.killer_type_is(betrayal) and global.player[0].number[0] == global.player[1].number[0] then 
         global.player[1].score += script_option[9]
      end
   end
end

if script_option[2] == 1 and global.object[0] == no_object then 
   global.object[0] = get_random_object("inf_haven", global.object[1])
   if global.number[1] == 1 then 
      send_incident(hill_moved, all_players, all_players)
   end
   global.number[1] = 1
end

if script_option[2] == 1 and global.timer[0].is_zero() then 
   global.timer[0].set_rate(0%)
   global.timer[0] = script_option[3]
   global.object[0].set_waypoint_visibility(no_one)
   global.object[0].set_shape_visibility(no_one)
   global.object[0].set_waypoint_timer(none)
   global.object[0].number[0] = 0
   global.object[1] = global.object[0]
   global.object[0] = no_object
   global.object[0] = get_random_object("inf_haven", global.object[1])
end

do
   global.object[0].set_waypoint_visibility(everyone)
   global.object[0].set_waypoint_icon(crown)
   global.object[0].set_shape_visibility(everyone)
   global.object[0].set_waypoint_priority(high)
end

if script_option[2] == 1 then 
   for each player do
      if global.object[0].shape_contains(current_player.biped) and current_player.number[0] == 0 and global.object[0].number[0] == 0 then 
         global.timer[0].set_rate(-100%)
         global.object[0].number[0] = 1
      end
   end
   if global.object[0].number[0] == 1 then 
      global.object[0].timer[0] = global.timer[0]
      global.object[0].set_waypoint_timer(0)
      if global.object[0].timer[0] < 6 then 
         global.object[0].set_waypoint_priority(blink)
      end
   end
end

if script_option[1] == 1 then 
   global.number[3] = 0
   if global.number[0] == 0 then 
      for each player do
         if not current_player.number[0] == 1 then 
            global.number[3] += 1
         end
      end
      if global.number[3] == 1 then 
         for each player do
            if not current_player.number[0] == 1 then 
               current_player.apply_traits(script_traits[1])
               current_player.biped.set_waypoint_icon(skull)
               current_player.biped.set_waypoint_priority(high)
               current_player.number[1] = 1
               current_player.score += script_option[11]
               send_incident(inf_last_man, current_player, all_players)
            end
         end
         global.number[0] = 1
      end
   end
end

for each player do
   if current_player.number[1] == 1 then 
      current_player.apply_traits(script_traits[1])
   end
end

for each player do
   script_widget[0].set_visibility(current_player, false)
   current_player.number[2] = 0
   if script_option[2] == 1 and global.object[0].shape_contains(current_player.biped) and current_player.number[0] == 0 then 
      current_player.number[2] = 1
      current_player.apply_traits(script_traits[2])
      script_widget[0].set_visibility(current_player, true)
   end
end

do
   global.timer[1].set_rate(-100%)
   if global.timer[1].is_zero() then 
      global.number[3] = 0
      for each player do
         if current_player.number[0] == 0 then 
            global.number[3] += 1
         end
      end
      for each player do
         if global.number[3] == 1 and current_player.number[0] == 0 and current_player.killer_type_is(suicide) then 
            global.number[3] = 0
         end
      end
      if global.number[3] == 0 then 
         send_incident(infection_zombie_win, all_players, all_players)
         for each player do
            if current_player.number[1] != 1 and current_player.number[0] == 1 then 
               current_player.score += script_option[4]
            end
         end
         game.end_round()
      end
   end
end

if game.round_timer.is_zero() and game.round_time_limit > 0 then 
   global.number[3] = 0
   for each player do
      if current_player.number[0] == 0 then 
         global.number[3] += 1
      end
   end
   if not global.number[3] == 0 then 
      send_incident(infection_survivor_win, all_players, all_players)
      for each player do
         if current_player.number[0] == 0 then 
            current_player.score += script_option[5]
         end
      end
      game.end_round()
   end
end

for each player do
   if current_player.number[0] == 0 then 
      current_player.timer[2].set_rate(-100%)
      if current_player.timer[2].is_zero() then 
         current_player.script_stat[0] += 1
         current_player.timer[2].reset()
      end
   end
   if current_player.number[0] == 1 then 
      current_player.timer[0].set_rate(-100%)
   end
end
